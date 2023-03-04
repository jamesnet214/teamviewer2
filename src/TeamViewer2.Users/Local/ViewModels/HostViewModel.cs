using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using System.Windows.Media.Imaging;

namespace TeamViewer2.Users.Local.ViewModels
{
    public partial class HostViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private BitmapSource _captureImage;

        public HostViewModel(IEventAggregator ea) 
        {
            _ea = ea;
        }
    }
}
