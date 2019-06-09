using System;
using System.Collections.Generic;

using Library_management.View.Enums;
using Library_management.View.Interfaces;
using Library_management.Services.WindowManagerInitializer;

namespace Library_management.Services
{
    /// <summary>
    /// Provides algorithms with window.
    /// <para />
    /// Implements a Factory pattern.
    /// <para />
    /// Implements a Singleton pattern
    /// </summary>
    public class WindowManager : Core.Services.Factory<System.Windows.Window>
    {
        // FIELDS
        static WindowManager instance; // singleton
        static WindowManagerInitializerBase initializerBase;

        IDictionary<string, Type> factory; // a factory has string as a key and WindowType as a value, create window by current key
        IDictionary<string, System.Windows.Window> modalWindows; // all currently opened modal windows
        IDictionary<object, System.Windows.Window> presentationWindow; // not modal window

        // CONSTRUCTORS
        private WindowManager()
        {
            // initialize all fields
            factory = new Dictionary<string, Type>();
            presentationWindow = new Dictionary<object, System.Windows.Window>();
            modalWindows = new Dictionary<string, System.Windows.Window>();

            // registrate default window
            initializerBase?.Initialize(this);
        }
        static WindowManager()
        {
            // initialize window initializer
            initializerBase = new DefaultWindowInitializers();

            // initialize singleton value
            instance = new WindowManager();
        }
        ~WindowManager()
        {
            foreach (System.Windows.Window window in modalWindows.Values)
            {
                window.Close();
            }
            modalWindows.Clear();

            foreach (System.Windows.Window window in presentationWindow.Values)
            {
                window.Close();
            }
            presentationWindow.Clear();
        }
        // PROPERTIES
        public static WindowManager Instance => instance;

        // METHODS
        public void SetInitializer(WindowManagerInitializerBase windowInitializers)
        {
            // checking
            if (windowInitializers == null) throw new ArgumentNullException(nameof(windowInitializers));

            // change initializer
            initializerBase = windowInitializers;

            // initialize with new value
            instance.factory.Clear();
            windowInitializers.Initialize(instance);
        }
        
        // dialog window
        #region DialogWindow
        public bool? ShowWindowDialog(string key)
        {
            return ShowWindowDialog(key, null);
        }
        public bool? ShowWindowDialog(string key, object viewModel)
        {
            // create window
            System.Windows.Window window = MakeInstance(key);
            // set view model
            window.DataContext = viewModel;

            // remove if closed with other method
            RemoveIfClosed(key);

            // save modal window to dictionary
            modalWindows.Add(key, window);

            // show window
            return window.ShowDialog();
        }
        private void RemoveIfClosed(string key)
        {
            // checking
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(key);

            // try get window
            System.Windows.Window openedModalWindow;
            if (modalWindows.TryGetValue(key, out openedModalWindow) == false)
            {
                // no key, return
                return;
            }

            // remove if is not active
            if (!openedModalWindow.IsActive)
            {
                modalWindows.Remove(key);
            }
        }
        public void CloseModalWindow(string key)
        {
            // checking
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(key);

            // try get window
            System.Windows.Window openedModalWindow;
            if (modalWindows.TryGetValue(key, out openedModalWindow) == false)
            {
                // window is not opened
                // or is not opened as modal
                throw new InvalidOperationException("Modal window is not opened");
            }

            // close window or do nothing
            openedModalWindow.Close();

            // remove window from dictionary
            modalWindows.Remove(key);
        }
        #endregion
        // open file dialog
        #region OpenFileDialog
        public string[] OpenFileDialog(string filterString)
        {
            return OpenFileDialog(filterString, isMultiselectAllowed: false);
        }
        public string[] OpenFileDialog(string filterString, bool isMultiselectAllowed)
        {
            // make generic instance 
            IFileDialog openFileDialog = MakeInstance(initializerBase.OpenFileDialogName) as IFileDialog;
            // throw exception if not the file dialog
            if (openFileDialog == null) throw new InvalidCastException($"Dialog does not inherit default interface {nameof(IFileDialog)}");

            // sets up values
            openFileDialog.Multiselect = isMultiselectAllowed;
            openFileDialog.Filter = filterString;

            // show dialog and return result or NULL if user canceled operation
            if (openFileDialog.ShowDialog() == true) return openFileDialog.FileNames;
            return null;
        }
        #endregion
        // message box
        #region MessageBox
        public bool? ShowMessageBoxWindow(string text)
        {
            return ShowMessageBoxWindow(text, String.Empty, MessageBoxButton.Ok);
        }
        public bool? ShowMessageBoxWindow(string text, string header)
        {
            return ShowMessageBoxWindow(text, header, MessageBoxButton.Ok);
        }
        public bool? ShowMessageBoxWindow(string text, string header, MessageBoxButton buttonType)
        {
            // make default instance             
            IMessageBox messageBox = MakeInstance(initializerBase.MessageBoxName) as IMessageBox;
            // throw exception if not the message box
            if (messageBox == null) throw new InvalidCastException($"Dialog does not inherit default interface {nameof(IMessageBox)}");

            // sets up all values
            messageBox.Header = header;
            messageBox.Text = text;

            // show window and return result
            return messageBox.ShowDialog(buttonType);
        }
        #endregion
        // main window
        #region main window
        public void SwitchMainWindow(string key)
        {
            SwitchMainWindow(key, null);
        }
        public void SwitchMainWindow(string key, object viewModel, bool doCloseAllWindow = false)
        {
            // get current main window
            System.Windows.Window oldMainWindow = App.Current.MainWindow;

            // get new window by key
            System.Windows.Window newMainWindow = MakeInstance(key);
            newMainWindow.DataContext = viewModel;

            // set it as a new main window
            App.Current.MainWindow = newMainWindow;

            // switch windows
            if (doCloseAllWindow)
            {
                // close all opened window
                foreach (System.Windows.Window window in App.Current.Windows)
                {
                    if (window != newMainWindow) window.Close();
                }

                // clear all modal window list
                modalWindows.Clear();
                // clear presentation window list
                presentationWindow.Clear();
            }
            else
            {
                // close only current main window
                oldMainWindow.Close();
            }
            newMainWindow.ShowDialog();
        }
        #endregion
        // presentation
        #region presentation
        public void ShowPresentation(string key, object viewModel)
        {
            // check, key is checked in MakeInstance
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            // create window
            System.Windows.Window window = MakeInstance(key);
            // set view model
            window.DataContext = viewModel;

            // add it to window
            presentationWindow.Add(viewModel, window);

            // show it
            window.Show();
        }
        public void ClosePresentation(object viewModel)
        {
            // check
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            // try get opened window. throws exception if window is not shwon
            System.Windows.Window openedWindow;
            if (!presentationWindow.TryGetValue(viewModel, out openedWindow))
            {
                throw new InvalidOperationException("Window is not opened");
            }
            // remove opened window from list
            presentationWindow.Remove(viewModel);
            // close this window
            openedWindow.Close();
        }
        #endregion
    }
}
