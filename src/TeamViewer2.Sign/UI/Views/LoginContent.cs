﻿using System.Windows;
using TeamViewer2.Core;

namespace TeamViewer2.Sign.UI.Views
{
    public class LoginContent : PrismContent
    {
        static LoginContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LoginContent), new FrameworkPropertyMetadata(typeof(LoginContent)));
        }
    }
}
