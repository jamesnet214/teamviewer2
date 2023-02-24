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

            Loaded += PrismContent_Loaded;
        }

        private void PrismContent_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IViewLoadable loadableView)
            { 
                loadableView.OnLoaded(this);
            }
        }

        private void WireViewModelChanged(object arg1, object arg2)
        {
            if (arg1 is FrameworkElement fe && arg2 is INotifyPropertyChanged vm)
            {
                fe.DataContext = vm;
            }
        }
    }
}
