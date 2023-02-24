using System.Windows;
using System.Windows.Input;
using TeamViewer2.Core;

namespace TeamViewer2.Forms.UI.Views
{
    public class MainWindow : Window
    {
        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow), new FrameworkPropertyMetadata(typeof(MainWindow)));
        }

        public MainWindow()
        {

        }
    }
}
