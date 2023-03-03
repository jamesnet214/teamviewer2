using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Windows;
using System.Xml.Linq;
using TeamViewer2.Core;
using TeamViewer2.Core.Models;
using TeamViewer2.Receiver;

namespace TeamViewer2.Forms.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableObject, IViewLoadable
    {
        private readonly HubManager _hubManager;
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        private string _id;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _seat;

        public LoginContentViewModel(HubManager hubConnectionManager, IRegionManager regionManager, IContainerExtension container, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _container = container;
            _ea = ea;
            _hubManager = hubConnectionManager;
        }

        public void OnLoaded(PrismContent view)
        {
            _hubManager.Start(_ea);
        }

        [RelayCommand]
        private async void Login()
        {
            UserModel loginInfo = new()
            {
                Id = Id,
                Name = Name,
                Seat = int.Parse(Seat),
                GUID = _hubManager.Connection.ConnectionId
            };

            MessageModel model = new();
            model.UserInfo = loginInfo;
            model.DataType = "Login";

            await _hubManager.Connection.InvokeAsync("SendMessage", model);

            //_ea.GetEvent<PubSubEvent<UserModel>>().Publish(loginInfo);
        }
    }
}
