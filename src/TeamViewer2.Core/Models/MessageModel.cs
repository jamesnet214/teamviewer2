using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media.Imaging;

namespace TeamViewer2.Core.Models
{
    public partial class MessageModel : ObservableObject
    {
        public string DataType { get; set; }
        public string Raw { get; set; }
        public UserModel UserInfo { get; set; }

        [ObservableProperty]
        private BitmapSource _snapShot;
    }
}
