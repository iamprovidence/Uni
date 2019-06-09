
namespace Library_management.Services.WindowManagerInitializer
{
    public abstract class WindowManagerInitializerBase
    {
        // PROPERTIES
        public abstract string MessageBoxName { get; }
        public abstract string OpenFileDialogName { get; }

        // METHODS
        public abstract void Initialize(WindowManager windowManager);
    }
}
