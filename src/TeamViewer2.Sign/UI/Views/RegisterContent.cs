using System.Windows;
using TeamViewer2.Core;

namespace TeamViewer2.Sign.UI.Views
{
    public class RegisterContent : PrismContent
    {
        static RegisterContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RegisterContent), new FrameworkPropertyMetadata(typeof(RegisterContent)));
        }
    }
}
