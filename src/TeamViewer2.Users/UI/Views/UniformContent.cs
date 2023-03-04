using System.Windows;
using TeamViewer2.Core;

namespace TeamViewer2.Users.UI.Views
{
    public class UniformContent : PrismContent
    {
        static UniformContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UniformContent), new FrameworkPropertyMetadata(typeof(UniformContent)));
        }
    }
}
