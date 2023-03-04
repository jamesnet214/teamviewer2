using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.IO;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TeamViewer2.Core;
using TeamViewer2.Core.Events;
using TeamViewer2.Core.Models;
using TeamViewer2.Receiver;

namespace TeamViewer2.Forms.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableObject, IViewLoadable
    {
        private readonly HubManager _hubManager;
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private readonly IEventAggregator _ea;
        private MessageModel loginInfo { get; set; }

        public MainContentViewModel(HubManager hubManager, IRegionManager regionManager, IContainerExtension container, IEventAggregator ea)
        {
            _hubManager = hubManager;
            _regionManager = regionManager;
            _container = container;
            _ea = ea;

            _ea.GetEvent<LoginCompletedEvent>().Subscribe(LoginCompleted);
        }

        public void OnLoaded(PrismContent view)
        {
            IRegion contentRegion = _regionManager.Regions["CurrentRegion"];
            PrismContent currentContent = _container.Resolve<PrismContent>(ContentName.CurrentContent);

            if (!contentRegion.Views.Contains(currentContent))
            {
                contentRegion.Add(currentContent);
            }
            contentRegion.Activate(currentContent);

            IRegion uniformRegion = _regionManager.Regions["UniformRegion"];
            PrismContent uniformContent = _container.Resolve<PrismContent>(ContentName.UniformContent);

            if (!uniformRegion.Views.Contains(uniformContent))
            {
                uniformRegion.Add(uniformContent);
            }
            uniformRegion.Activate(uniformContent);

            _ea.GetEvent<InitializeCurrentUserEvent>().Publish(loginInfo.UserInfo);
        }

        [RelayCommand]
        private async void ImageCapture(BitmapSource bi)
        {
            _ea.GetEvent<CopiedImageSendEvent>().Publish(bi);
            loginInfo.Raw = BitmapSourceToBase64(bi);
            await _hubManager.Connection.InvokeAsync("SendMessage", loginInfo);
        }

        private async void LoginCompleted(MessageModel userInfo)
        {
            loginInfo = userInfo;
            await _hubManager.Connection.InvokeAsync("SendMessage", loginInfo);
        }

        public static string BitmapSourceToBase64(BitmapSource bitmapSource)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
