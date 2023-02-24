using System.Windows;
using System.Windows.Controls;
using TeamViewer2.Core;

namespace TeamViewer2.UserBox.UI.Views
{
    public class ScreenContent : PrismContent
    {
        static ScreenContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScreenContent), new FrameworkPropertyMetadata(typeof(ScreenContent)));
        }
    }
}
