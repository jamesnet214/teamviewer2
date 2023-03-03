using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TeamViewer2.Core;
using TeamViewer2.Core.Events;
using TeamViewer2.Core.Models;

namespace TeamViewer2.Forms.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableObject, IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly IEventAggregator _ea;
        private UserModel _userInfo;

        public MainContentViewModel(IRegionManager regionManager, IContainerExtension container, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _container = container;
            _ea = ea;

            _ea.GetEvent<PubSubEvent<UserModel>>().Subscribe(LoginCompleted);
        }

        public void OnLoaded(PrismContent view)
        {
            if (Window.GetWindow(view) is Window win)
            {
                win.PreviewKeyDown += Win_PreviewKeyDown;
            }
            _ea.GetEvent<InitializeCurrentUserEvent>().Publish(_userInfo);
        }

        private void Win_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (Clipboard.ContainsImage())
                {
                    //string clipboardText = Clipboard.GetText();
                    // 클립보드에서 텍스트 데이터 가져오기

                    BitmapSource clipboardImage = Clipboard.GetImage();
                    PreviewKeyDownCommand?.Execute(clipboardImage);
                }
            }
        }

        [RelayCommand]
        private void PreviewKeyDown(BitmapSource bi)
        {
            _ea.GetEvent<CopiedImageSendEvent>().Publish(bi);  
        }

        private void LoginCompleted(UserModel userInfo)
        {
            _userInfo = userInfo;
        }
    }
}
