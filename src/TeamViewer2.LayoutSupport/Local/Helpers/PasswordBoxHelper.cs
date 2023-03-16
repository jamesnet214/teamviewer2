using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TeamViewer2.LayoutSupport.UI.Units;

namespace TeamViewer2.LayoutSupport.Local.Helpers
{
    public static class PasswordBoxHelper
    {

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached(
            "Password", typeof(string), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(string.Empty, OnPasswordChanged ));

        public static string GetPassword(DependencyObject d)
        {
            return (string)d.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PlaceholderPasswordBox customPasswordBox)
            {
                customPasswordBox.Text = (string)e.NewValue;
            }
        }
    }
}
