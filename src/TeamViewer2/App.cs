using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System.Collections.Generic;
using System.Windows;
using TeamViewer2.Core;
using TeamViewer2.Forms.Local.ViewModels;
using TeamViewer2.Forms.UI.Views;
using TeamViewer2.Sign.Local.ViewModels;
using TeamViewer2.Sign.UI.Views;
using TeamViewer2.Users.Local.ViewModels;
using TeamViewer2.Users.UI.Views;

namespace TeamViewer2
{
    public class App : PrismApplication
    {
        private List<IModule> _modules;

        public App()
        {
            _modules = new();
        }

        protected override Window CreateShell()
        {
            return new MainWindow();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<PrismContent, LoginContent>(ContentName.LoginContent);
            containerRegistry.RegisterInstance<PrismContent>(new MainContent(), ContentName.MainContent);
            containerRegistry.RegisterInstance<PrismContent>(new UniformContent(), ContentName.UniformContent);
            containerRegistry.RegisterInstance<PrismContent>(new CurrentContent(), ContentName.CurrentContent);
            containerRegistry.RegisterInstance<PrismContent>(new HostContent(), ContentName.HostContent);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            foreach (IModule module in _modules)
            {
                moduleCatalog.AddModule(module.GetType());
            }
        }

        internal App WireViewModel()
        {
            ViewModelLocationProvider.Register<MainContent, MainContentViewModel>();
            ViewModelLocationProvider.Register<LoginContent, LoginContentViewModel>();
            ViewModelLocationProvider.Register<ScreenContent, ScreenViewModel>();
            ViewModelLocationProvider.Register<CurrentContent, CurrentViewModel>();
            ViewModelLocationProvider.Register<HostContent, HostViewModel>();
            ViewModelLocationProvider.Register<UniformContent, UniformViewModel>();

            return this;
        }

        internal App AddModule<T>() where T : IModule, new()
        {
            IModule module = new T();
            _modules.Add(module);

            return this;
        }
    }
}
