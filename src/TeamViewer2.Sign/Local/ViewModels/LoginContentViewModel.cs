﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using TeamViewer2.Core;
using TeamViewer2.Core.Events;
using TeamViewer2.Core.Models;
using TeamViewer2.Receiver;

namespace TeamViewer2.Sign.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableObject, IViewLoadable
    {
        private readonly HubManager _hubManager;
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly IEventAggregator _ea;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _password;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _email;

        [ObservableProperty]
        private string _seat;

        public LoginContentViewModel(HubManager hubManager, IRegionManager regionManager, IContainerExtension container, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _container = container;
            _ea = ea;
            _hubManager = hubManager;
        }

        public void OnLoaded(PrismContent view)
        {
            _hubManager.Start(_ea);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private void Login()
        {
            UserModel loginInfo = new()
            {
                Id = Password,
                Name = Email,
                Seat = 0,
                GUID = _hubManager.Connection.ConnectionId
            };

            MessageModel model = new();
            model.UserInfo = loginInfo;
            model.DataType = "Login";

            IRegion region = _regionManager.Regions["MainRegion"];
            var view = _container.Resolve<PrismContent>(ContentName.MainContent);

            if (!region.Views.Contains(view))
            {
                region.Add(view);
            }
            region.Activate(view);

            _ea.GetEvent<LoginCompletedEvent>().Publish(model);
        }
    }
}
