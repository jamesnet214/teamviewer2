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
    public partial class ScreenViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private BitmapSource _captureImage;

        public ScreenViewModel(IEventAggregator ea) 
        {
        }
    }
}
