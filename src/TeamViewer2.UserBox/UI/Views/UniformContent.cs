﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamViewer2.Core;

namespace TeamViewer2.UserBox.UI.Views
{
    public class UniformContent : PrismContent
    {
        static UniformContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UniformContent), new FrameworkPropertyMetadata(typeof(UniformContent)));
        }
    }
}