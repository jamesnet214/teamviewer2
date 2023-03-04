using System.Windows;
using System.Windows.Controls;

namespace TeamViewer2.Users.UI.Units
{
    public class ThumbnailList : ListBox
    {
        static ThumbnailList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ThumbnailList), new FrameworkPropertyMetadata(typeof(ThumbnailList)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ThumbnailListItem();
        }
    }
}
