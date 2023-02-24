using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using System.Windows.Media.Imaging;
using TeamViewer2.Core;
using TeamViewer2.Forms.Local.Models;
using TeamViewer2.Forms.UI.Views;

namespace TeamViewer2.Forms.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableObject, IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private string _id;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _seat;

        [ObservableProperty]
        private Visibility _loginVisibility;

        public LoginContentViewModel(IRegionManager regionManager, IContainerExtension container, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _container = container;
            _ea = ea;
        }

        public void OnLoaded(PrismContent view)
        {
        }

        [RelayCommand]
        private void Login()
        {
            IRegion region = _regionManager.Regions["MainRegion"];
            var uniformContent = _container.Resolve<PrismContent>(ContentName.MainContent);
            var d2 = _container.Resolve<PrismContent>(ContentName.MainContent);

            if (!region.Views.Contains(uniformContent))
            {
                region.Add(uniformContent);
            }

            region.Activate(uniformContent);

            //LoginVisibility = Visibility.Collapsed;
            //_ea.GetEvent<PubSubEvent<UserModel>>().Publish(new UserModel { Id = Id, Name = Name, Seat = int.Parse(Seat)});
        }
    }
}
