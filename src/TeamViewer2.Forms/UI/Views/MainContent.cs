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
            Loaded += MainContent_Loaded;   
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Window win)
            {
                win.PreviewKeyDown += MainContent_PreviewKeyDown;
            }
        }

        private void MainContent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (Clipboard.ContainsImage())
                {
                    //string clipboardText = Clipboard.GetText();
                    // 클립보드에서 텍스트 데이터 가져오기

                    BitmapSource clipboardImage = Clipboard.GetImage();
                    PreviewKeyDownCommand?.Execute(clipboardImage);
                }
            }
        }
    }
}
