using System.Windows;
using TeamViewer2.Core;

namespace TeamViewer2.Users.UI.Views
{
    public class ScreenContent : PrismContent
    {
        static ScreenContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScreenContent), new FrameworkPropertyMetadata(typeof(ScreenContent)));
        }
    }
}
