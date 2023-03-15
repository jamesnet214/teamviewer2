using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using TeamViewer2.Core.Models;

namespace TeamViewer2.Users.Local.ViewModels
{
    public partial class UniformViewModel : ObservableObject
    {
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private UserModel _userInfo;

        [ObservableProperty]
        private BitmapSource _captureImage;

        [ObservableProperty]
        private ObservableCollection<MessageModel> _users;

        public UniformViewModel(IEventAggregator ea) 
        {
            _ea = ea;
            _ea.GetEvent<PubSubEvent<MessageModel>>().Subscribe(UserMessage);

            _users = new();
        }

        private void UserMessage(MessageModel obj)
        {
            if (Users.FirstOrDefault(x => x.UserInfo.Name == obj.UserInfo.Name) is null)
            {
                Users.Add(obj);
            }

            MessageModel current = Users.Single(x => x.UserInfo.GUID == obj.UserInfo.GUID);
            current.SnapShot = Base64ToBitmapSource(obj.Raw);
        }

        public static BitmapSource Base64ToBitmapSource(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            var bitImg = new BitmapImage();

            using (var stream = new MemoryStream(bytes))
            {
                bitImg.BeginInit();
                bitImg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bitImg.CacheOption = BitmapCacheOption.OnLoad;
                bitImg.StreamSource = stream;
                bitImg.EndInit();

                return bitImg;
            }

        }
    }
}
