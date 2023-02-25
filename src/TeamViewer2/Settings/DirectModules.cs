﻿using Prism.Ioc;
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
            
        }
    }
}