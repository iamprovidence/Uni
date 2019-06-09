namespace Library_management.ViewModel.Structs
{
    class SelectedItem<TItem>
    {
        public virtual bool IsSelected { get; set; }
        public virtual TItem Item { get; set; }
    }
}
