﻿using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace TeamViewer2.Core
{
    public class PrismRegion : ContentControl
    {
        public static readonly DependencyProperty ContentNameProperty = DependencyProperty.Register("RegionName", typeof(string), typeof(PrismRegion), new PropertyMetadata(ContentNamePropertyChanged));

        public string RegionName
        {
            get => (string)GetValue(ContentNameProperty);
            set => SetValue(ContentNameProperty, value);
        }

        private static void ContentNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string str
                && string.IsNullOrEmpty(str) == false
                && Application.Current?.CheckAccess() == true)
            {
                IRegionManager rm = RegionManager.GetRegionManager(Application.Current.MainWindow);
                RegionManager.SetRegionName((PrismRegion)d, str);
                RegionManager.SetRegionManager(d, rm);
            }
        }

        public PrismRegion()
        {
        }
    }
}
