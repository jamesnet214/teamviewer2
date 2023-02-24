using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using System.Windows.Media.Imaging;
using TeamViewer2.Core;
using TeamViewer2.Forms.Local.Models;

namespace TeamViewer2.Forms.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableObject, IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private Visibility _loginVisibility;

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
            var uniformContent = _container.Resolve<PrismContent>(ContentName.UniformContent); 
            
            if (!region.Views.Contains(uniformContent))
            {
                region.Add(uniformContent);
            }

            region.Activate(uniformContent);
        }

        [RelayCommand]
        private void PreviewKeyDown(BitmapSource bi)
        {
            _ea.GetEvent<PubSubEvent<BitmapSource>>().Publish(bi);  
        }

        private void LoginCompleted(UserModel info)
        { 
            //LoginVisibility = Visibility.Collapsed;
        }
    }
}
