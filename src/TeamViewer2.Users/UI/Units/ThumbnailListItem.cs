using System.Windows;
using System.Windows.Controls;

namespace TeamViewer2.Users.UI.Units
{
    public class ThumbnailListItem : ListBoxItem
    {
        static ThumbnailListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ThumbnailListItem), new FrameworkPropertyMetadata(typeof(ThumbnailListItem)));
        }
    }
}
