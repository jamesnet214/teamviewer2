using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TeamViewer2.LayoutSupport.UI.Units
{
    public class PlaceholderPasswordBox : TextBox
    {
        private PasswordBox _passwordBox;

        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PlaceholderPasswordBox), new PropertyMetadata(""));



        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        static PlaceholderPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlaceholderPasswordBox), new FrameworkPropertyMetadata(typeof(PlaceholderPasswordBox)));
        }
        public PlaceholderPasswordBox()
        {
            this.GotFocus += CustomPasswordBox_GotFocus;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_PasswordBox") is PasswordBox pwd)
            {
                pwd.PasswordChanged += Pwd_PasswordChanged;
            }
        }

        private void Pwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pwd)
            {
                SetValue(TextProperty, pwd.Password);
            }
        }

        private void CustomPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == this)
            {
                PasswordBox passwordBox = GetTemplateChild("PART_PasswordBox") as PasswordBox;
                if (passwordBox != null)
                {
                    passwordBox.Focus();
                }
            }
        }
    }
}
