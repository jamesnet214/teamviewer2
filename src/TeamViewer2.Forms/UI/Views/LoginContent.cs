using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TeamViewer2.Core;

namespace TeamViewer2.Forms.UI.Views
{
    public class LoginContent : PrismContent
    {
        static LoginContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LoginContent), new FrameworkPropertyMetadata(typeof(LoginContent)));
        }
    }
}
