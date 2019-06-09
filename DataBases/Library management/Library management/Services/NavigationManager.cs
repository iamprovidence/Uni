using System;
using System.Collections.Generic;
using System.Windows.Controls;

using Library_management.Services.NavigationManagerInitializer;

namespace Library_management.Services
{
    public class NavigationManager : Core.Services.Factory<UserControl>
    {
        // FIELDS
        Stack<KeyValuePair<Type, object>> history; // control type, view model object
        NavigationManagerInitializerBase initializerBase;
        ContentControl mainContent;

        static readonly NavigationManager instance;

        // CONSTRUCTORS
        private NavigationManager()
        {
            history = new Stack<KeyValuePair<Type, object>>();
            mainContent = null;

            initializerBase = new DefaultNavigationManagerInitilizer();

            Initialize();
        }
        static NavigationManager()
        {
            // initialize singleton value
            instance = new NavigationManager();
        }
        private void Initialize()
        {
            if (initializerBase != null)
            {
                HiddenFactory.Clear();
                history.Clear();

                initializerBase.Initialize(this);
            }
        }
        public void SetInitializer(NavigationManagerInitializerBase navigationInitializer)
        {
            // checking
            if (navigationInitializer == null) throw new ArgumentNullException(nameof(navigationInitializer));

            // change initializer
            initializerBase = navigationInitializer;

            // initialize with new value
            Initialize();
        }

        // PROPERTIES
        public static NavigationManager Instance => instance;

        public ContentControl MainContent
        {
            get
            {
                return mainContent;
            }
            set
            {
                mainContent = value;
            }
        }

        // METHODS
        // history
        #region manage history
        public void PopHistory()
        {
            if (history.Count > 0) history.Pop();
        }
        public void ClearHistory()
        {
            history.Clear();
        }
        public UserControl PreviousInstance()
        {
            if (history.Count <= 0) return null;

            // gets user control and view model from history
            KeyValuePair<Type, object> controlDataContext = history.Peek();

            // create user control and sets view mode
            UserControl userControl = (UserControl)Activator.CreateInstance(controlDataContext.Key);

            // create new ViewModel from type if can
            if (controlDataContext.Value != null && HasDefaultConstructor(controlDataContext.Value.GetType()))
            {
                userControl.DataContext = Activator.CreateInstance(controlDataContext.Value.GetType());
            }
            else // use saved ViewModel
            {
                userControl.DataContext = controlDataContext.Value;
            }

            // gets value
            return userControl;
        }
        #endregion
        // navigation
        #region navigation
        public void NavigateTo(ContentControl parent, string key, object viewModel)
        {
            // sets to parent control navigate control value
            parent.Content = NavigateTo(key, viewModel);
        }
        public UserControl NavigateTo(string key, object viewModel)
        {
            // create child control
            UserControl userControl = MakeInstance(key);
            // sets viewModel to it
            userControl.DataContext = viewModel;

            // save instance type in history
            history.Push(new KeyValuePair<Type, object>(userControl.GetType(), userControl.DataContext));

            return userControl;
        }
        public void NavigateToPrevious(ContentControl parent, object viewModel)
        {
            // sets to current control previous value 
            parent.Content = NavigateToPrevious(viewModel); // null or user control
        }
        public void NavigateToPrevious(ContentControl parent, bool doSearchForDefault = false)
        {
            // sets to current control previous value 
            parent.Content = NavigateToPrevious(doSearchForDefault);

        }
        public UserControl NavigateToPrevious(object viewModel)
        {
            // get previous control
            UserControl userControl = NavigateToPrevious();

            // sets viewModel to it
            if (userControl != null) userControl.DataContext = viewModel;

            return userControl;
        }
        public UserControl NavigateToPrevious(bool doSearchForDefault = false)
        {
            // get previous control
            UserControl userControl;

            do
            {
                // remove current from history
                PopHistory();

                // try get previous control
                userControl = PreviousInstance();

                // while control and ViewModel is not null
                // and while user want to search for default Control
            } while (userControl != null && userControl.DataContext != null &&
                     doSearchForDefault && !HasDefaultConstructor(userControl.DataContext.GetType()));

            return userControl;
        }
        #endregion
        // additional methods
        #region additional methods
        private bool HasDefaultConstructor(Type type)
        {
            return type.IsValueType || type.GetConstructor(Type.EmptyTypes) != null;
        }
        #endregion
    }
}
