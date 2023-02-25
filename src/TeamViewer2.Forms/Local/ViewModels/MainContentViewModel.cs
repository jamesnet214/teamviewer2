using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
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
            _regionManager.RegisterViewWithRegion("CurrentRegion", ContentName.CurrentContent);
            _regionManager.RegisterViewWithRegion("HostRegion", ContentName.HostContent);

            IRegion region = _regionManager.Regions["UniformRegion"];
            PrismContent uniformContent = _container.Resolve<PrismContent>(ContentName.UniformContent); 
            
            if (!region.Views.Contains(uniformContent))
            {
                region.Add(uniformContent);
            }
            region.Activate(uniformContent);

            _ea.GetEvent<InitializeCurrentUserEvent>().Publish(_userInfo);
        }

        [RelayCommand]
        private void PreviewKeyDown(BitmapSource bi)
        {
            _ea.GetEvent<CopiedImageSendEvent>().Publish(bi);  
        }

        private void LoginCompleted(UserModel userInfo)
        {
            _userInfo = userInfo;

            IRegion region = _regionManager.Regions["MainRegion"];
            PrismContent main = _container.Resolve<PrismContent>(ContentName.MainContent);

            if (!region.Views.Contains(main))
            {
                region.Add(main);
            }
            region.Activate(main);
        }
    }
}
