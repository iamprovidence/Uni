using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library_management.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // FIELDS        
        readonly Services.WindowManager windowManager;
        readonly Services.NavigationManager navigationManager;
        readonly DataAccess.Context.UnitOfWork unitOfWork;

        // EVENTS
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        public ViewModelBase()
        {
            windowManager = Services.WindowManager.Instance;
            navigationManager = Services.NavigationManager.Instance;
            unitOfWork = DataAccess.Context.UnitOfWork.Instance;
        }

        // PROPERTIES
        public Services.WindowManager WindowManager => windowManager;
        public Services.NavigationManager NavigationManager => navigationManager;
        public DataAccess.Context.UnitOfWork UnitOfWork => unitOfWork;

        // METHODS
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        protected virtual void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, string propertyName = "")
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }    
}
