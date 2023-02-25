using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TeamViewer2.Core.Events;
using TeamViewer2.Core.Models;

namespace TeamViewer2.Users.Local.ViewModels
{
    public partial class CurrentViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private UserModel _userInfo;

        [ObservableProperty]
        private BitmapSource _captureImage;

        public CurrentViewModel(IEventAggregator ea) 
        {
            _ea = ea;

            _ea.GetEvent<CopiedImageSendEvent>().Subscribe(ImageCopied);
            _ea.GetEvent<InitializeCurrentUserEvent>().Subscribe(InitUserInfo);
        }

        private void InitUserInfo(UserModel userInfo)
        {
            UserInfo = userInfo;
        }

        private void ImageCopied(BitmapSource obj)
        {
            CaptureImage = obj;
        }
    }
}
