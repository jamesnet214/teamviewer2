using System.Windows;
using System.Windows.Controls;
using TeamViewer2.Core;

namespace TeamViewer2.Users.UI.Views
{
    public class CurrentContent : ScreenContent
    {
        static CurrentContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CurrentContent), new FrameworkPropertyMetadata(typeof(CurrentContent)));
        }
    }
}
