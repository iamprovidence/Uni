using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Library_management
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        // CONST
        private static readonly string APP_NAME = "Library management";

        // FIELDS
        private static Mutex mutex;


        // EXTERN METHODS
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);

        // METHODS
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            // handle unhadled exception
            this.DispatcherUnhandledException += FatalClose;

            // It is for single instance of application, when other application will be created it will redirect to first main one
            // and that other will be closed.
            bool isCreatedNewMutex;
            mutex = new Mutex(initiallyOwned: true, name: "LibraryManagementMutex", createdNew: out isCreatedNewMutex);

            // close another instance of the application
            if (!isCreatedNewMutex)
            {
                // Second application has been started up - redirected to main one

                // search for original program process
                int currentProcessId = Process.GetCurrentProcess().Id; // second process id
                Process process = Process.GetProcessesByName(APP_NAME).First(p => p.Id != currentProcessId);

                // shows original program main window
                ShowWindow(process.MainWindowHandle, 9); // 9 = SW_RESTORE, If the window is minimized or maximized, the system restores it to its original size and position.
                SetForegroundWindow(process.MainWindowHandle);

                // close second application
                this.Shutdown();
                return;
            }

            // call base startup
            base.OnStartup(e);
        }
        private void FatalClose(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // it will not work on Debug mode
            e.Handled = true;

            // show exception message
            Services.WindowManager.Instance.ShowMessageBoxWindow("Sorry, something went wrong", "Error", View.Enums.MessageBoxButton.Ok);
        }
    }
}
