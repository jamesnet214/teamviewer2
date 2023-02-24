using System.Windows;
using System.Windows.Controls;
using TeamViewer2.Core;

namespace TeamViewer2.UserBox.UI.Views
{
    public class HostContent : ScreenContent
    {
        static HostContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HostContent), new FrameworkPropertyMetadata(typeof(HostContent)));
        }
    }
}
