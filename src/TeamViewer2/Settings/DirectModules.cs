using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using TeamViewer2.Core;
using TeamViewer2.Forms.UI.Views;
using TeamViewer2.Receiver;
using TeamViewer2.Sign.UI.Views;
using TeamViewer2.Users.UI.Views;

namespace TeamViewer2.Settings
{
    internal class DirectModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", ContentName.LoginContent);
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

            containerRegistry.RegisterSingleton<PrismContent, LoginContent>(ContentName.LoginContent);
            containerRegistry.RegisterInstance<PrismContent>(new MainContent(), ContentName.MainContent);
            containerRegistry.RegisterInstance<PrismContent>(new UniformContent(), ContentName.UniformContent);
            containerRegistry.RegisterInstance<PrismContent>(new CurrentContent(), ContentName.CurrentContent);
            containerRegistry.RegisterInstance<PrismContent>(new HostContent(), ContentName.HostContent);
        }
    }
}
