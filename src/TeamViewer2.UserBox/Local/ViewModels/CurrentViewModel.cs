using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TeamViewer2.UserBox.Local.ViewModels
{
    public partial class CurrentViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private BitmapSource _captureImage;

        public CurrentViewModel(IEventAggregator ea) 
        {
            _ea = ea;

            _ea.GetEvent<PubSubEvent<BitmapSource>>().Subscribe(ImageCopied);
        }

        private void ImageCopied(BitmapSource obj)
        {
            CaptureImage = obj;
        }
    }
}
