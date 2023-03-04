using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TeamViewer2.Core
{
    public class PrismContent : ContentControl
    {
        public PrismContent()
        {
            ViewModelLocationProvider.AutoWireViewModelChanged(this, WireViewModelChanged);
        }

        private void PrismContent_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= PrismContent_Loaded;
            if (DataContext is IViewLoadable loadableView)
            { 
                loadableView.OnLoaded(this);
            }
        }

        private void WireViewModelChanged(object arg1, object arg2)
        {
            if (arg1 is FrameworkElement fe && arg2 is INotifyPropertyChanged vm)
            {
                if (arg2 is IViewLoadable loadableView)
                {
                    Loaded += PrismContent_Loaded;
                }
                fe.DataContext = vm;
            }
        }
    }
}
