using Library_management.View.Windows;
using Library_management.View.Windows.Dialog;

namespace Library_management.Services.WindowManagerInitializer
{
    public class DefaultWindowInitializers : WindowManagerInitializerBase
    {
        // PROPERTIES
        /// <summary>
        /// Gets message box name
        /// </summary>
        public override string MessageBoxName => nameof(MessageBox);

        public override string OpenFileDialogName => throw new System.NotImplementedException();

        // METHODS
        public override void Initialize(WindowManager windowManager)
        {
            // registrate all windows
            // registrate main window
            windowManager.Registrate(nameof(MainWindow), typeof(MainWindow));
            // registrate dialogs
            windowManager.Registrate(nameof(MessageBox), typeof(MessageBox));
        }
    }
}
