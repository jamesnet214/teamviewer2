using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TeamViewer2.Core;

namespace TeamViewer2.Forms.UI.Views
{
    public class MainContent : PrismContent
    {
        public static readonly DependencyProperty PreviewKeyDownCommandProperty = DependencyProperty.Register("PreviewKeyDownCommand", typeof(ICommand), typeof(MainContent));

        public ICommand PreviewKeyDownCommand
        {
            get { return (ICommand)GetValue(PreviewKeyDownCommandProperty); }
            set { SetValue(PreviewKeyDownCommandProperty, value); }
        }

        static MainContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainContent), new FrameworkPropertyMetadata(typeof(MainContent)));
        }

        public MainContent()
        {
        }
    }
}
