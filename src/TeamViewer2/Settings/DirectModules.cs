using Microsoft.AspNetCore.SignalR.Client;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamViewer2.Core;
using TeamViewer2.Forms.UI.Views;
using TeamViewer2.Receiver;

namespace TeamViewer2.Settings
{
    internal class DirectModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", ContentName.LoginContent);
            regionManager.RegisterViewWithRegion("CurrentRegion", ContentName.CurrentContent);
            regionManager.RegisterViewWithRegion("HostRegion", ContentName.HostContent);
            regionManager.RegisterViewWithRegion("UniformRegion", ContentName.UniformContent);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            HubManager conn = HubManager.Create();

            conn.Connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await conn.Connection.StartAsync();
            };

            containerRegistry.RegisterInstance(conn);
        }
    }
}
