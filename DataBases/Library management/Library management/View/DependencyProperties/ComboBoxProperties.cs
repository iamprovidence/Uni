using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Library_management.View.DependencyProperties
{
    public static class ComboBoxProperties
    {
        #region IS NULLABLE
        public static bool GetIsNullable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNullableProperty);
        }

        public static void SetIsNullable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNullableProperty, value);
        }

        public static readonly DependencyProperty IsNullableProperty =
            DependencyProperty.RegisterAttached(
                name:  "IsNullable",
                propertyType: typeof(bool), 
                ownerType: typeof(ComboBox),
                defaultMetadata: new UIPropertyMetadata(defaultValue: false, propertyChangedCallback: OnIsNullableChanged));

        private static void OnIsNullableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                ComboBox comboBox = (ComboBox)d;
                
                comboBox.Loaded += delegate 
                {
                    ChangeVisibilityOnClearButton(comboBox);

                    // add Click handler
                    Button clearButton = GetClearButton(comboBox);

                    if (clearButton != null) clearButton.Click += ClearButton_Click;
                };
                comboBox.SelectionChanged += delegate { ChangeVisibilityOnClearButton(comboBox); };
            }
        }
        private static void ChangeVisibilityOnClearButton(ComboBox comboBox)
        {
            bool isNullable = GetIsNullable(comboBox);
            Button clearButton = GetClearButton(comboBox);

            // if there is clear button
            // hide or show it
            if (clearButton != null)
            {
                if (isNullable && comboBox.SelectedIndex != -1)
                {
                    clearButton.Visibility = Visibility.Visible;
                }
                else
                {
                    clearButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private static void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // gets clear button
            Button clearButton = (Button)sender;

            // search for ComboBox
            DependencyObject parent = VisualTreeHelper.GetParent(clearButton);
            while (!(parent is ComboBox))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            // clear the selection
            ((ComboBox)parent).SelectedIndex = -1;
        }

        private static Button GetClearButton(DependencyObject reference)
        {
            // for each child
            for (int childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(reference); ++childIndex)
            {
                DependencyObject child = VisualTreeHelper.GetChild(reference, childIndex);

                // if child is ClearButton ...
                if (child is Button && ((Button)child).Name == "PART_ClearButton")
                {
                    // ... return it
                    return (Button)child;
                }

                // recursive call for each child
                Button clearButton = GetClearButton(child);
                if (clearButton is Button)
                {
                    return clearButton;
                }
            }

            return null;
        }
        #endregion

    }
}
