namespace Library_management.ViewModel.Structs
{
    /// <summary>
    /// Has been used in <see cref="ViewModel.ViewModels.Book.SingleItemViewModel"/>
    /// <para/>
    /// When state of check box has been changed, this class adds or remove value from collection
    /// </summary>
    /// <typeparam name="TItem">
    /// An entity type
    /// </typeparam>
    class SelectedItemCollection<TItem> : SelectedItem<TItem>
    {
        public override bool IsSelected
        {
            get
            {
                return base.IsSelected;
            }
            set
            {
                base.IsSelected = value;
                if (value == true && !CollectionToModify.Contains(Item))
                {
                    CollectionToModify.Add(Item);
                }
                else if (value == false && CollectionToModify.Contains(Item))
                {
                    CollectionToModify.Remove(Item);
                }
            }
        }
        public System.Collections.Generic.ICollection<TItem> CollectionToModify { get; set; }
    }
}
