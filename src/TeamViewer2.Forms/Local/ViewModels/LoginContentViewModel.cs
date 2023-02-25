using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using System.Xml.Linq;
using TeamViewer2.Core;
using TeamViewer2.Core.Models;

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
            LoginVisibility = Visibility.Collapsed;

            UserModel loginInfo = new UserModel
            {
                Id = Id,
                Name = Name,
                Seat = int.Parse(Seat)
            };

            _ea.GetEvent<PubSubEvent<UserModel>>().Publish(loginInfo);
        }
    }
}
