using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Library_management.View.DependencyProperties
{
    public class ImageButton : Button
    {
        // CONSTRUCTORS
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        // DEPENDENCY PROPERTIES
        // IMAGE
        #region IMAGE
        public ImageSource Image
        {
            get
            {
                return (ImageSource)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(
                name: nameof(Image),
                propertyType: typeof(ImageSource),
                ownerType: typeof(ImageButton), 
                typeMetadata: new PropertyMetadata(defaultValue: null));
        #endregion

        // IMAGE HEIGHT
        #region IMAGE HEIGHT
        public double ImageHeight
        {
            get
            {
                return (double)GetValue(ImageHeightProperty);
            }
            set
            {
                SetValue(ImageHeightProperty, value);
            }
        }
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(
                name: nameof(ImageHeight),
                propertyType: typeof(double),
                ownerType: typeof(ImageButton), 
                typeMetadata: new PropertyMetadata(defaultValue: Double.NaN));
        #endregion

        // IMAGE WIDTH
        #region IMAGE WIDTH
        public double ImageWidth
        {
            get
            {
                return (double)GetValue(ImageWidthProperty);
            }
            set
            {
                SetValue(ImageWidthProperty, value);
            }
        }
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register(
                name: nameof(ImageWidth), 
                propertyType: typeof(double),
                ownerType: typeof(ImageButton),
                typeMetadata: new PropertyMetadata(defaultValue: Double.NaN));
        #endregion
    }
}
