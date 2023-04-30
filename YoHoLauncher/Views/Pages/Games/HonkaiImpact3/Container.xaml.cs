// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace YoHoLauncher.Views.Pages.Games.HonkaiImpact3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Container : Page
    {
        public Container()
        {
            this.InitializeComponent();
        }

        private void GameNav_Loaded(object sender, RoutedEventArgs e)
        {
            GameFrame.Navigate(typeof(Pages.Launch));
        }

        private void GameNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            GameFrame.Navigate(Type.GetType("YoHoLauncher.Views.Pages.Games."
                                            + GameNav.Tag.ToString()
                                            + ".Pages."
                                            + ((NavigationViewItem)args.InvokedItemContainer).Tag.ToString()));
        }

        private void GameFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (NavigationViewItem item in GameNav.MenuItems.Union(GameNav.FooterMenuItems).Cast<NavigationViewItem>())
            {
                if (Type.GetType((string)item.Tag) == e.SourcePageType)
                {
                    GameNav.SelectedItem = item;
                    item.IsSelected = true;
                    return;
                }
            }
        }
    }
}
