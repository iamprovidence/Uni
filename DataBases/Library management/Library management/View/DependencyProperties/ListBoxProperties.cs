namespace Library_management.View.DependencyProperties
{
    public static class ListBoxProperties
    {
        // IS ENABLED WITH SCROLL
        #region IS ENABLED WITH SCROLL
        // has been use because if you disable list box, its scroll also get disabled
        public static readonly System.Windows.DependencyProperty IsEnabledWithScrollProperty =
            System.Windows.DependencyProperty.RegisterAttached(
                name: "IsEnabledWithScroll",
                propertyType: typeof(bool), 
                ownerType: typeof(ListBoxProperties));

        public static void SetIsEnabledWithScroll(System.Windows.DependencyObject element, bool value)
        {
            element.SetValue(IsEnabledWithScrollProperty, value);
        }
        public static bool GetIsEnabledWithScroll(System.Windows.DependencyObject element)
        {
            return (bool)element.GetValue(IsEnabledWithScrollProperty);
        }
        #endregion
    }
}
