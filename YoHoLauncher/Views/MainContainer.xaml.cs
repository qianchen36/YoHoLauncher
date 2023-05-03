// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace YoHoLauncher.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainContainer : Page
    {
        public static XamlRoot _XamlRoot { get; private set; }

        public MainContainer()
        {
            this.InitializeComponent();
        }

        private void RefreshDragArea()
        {
            var scaleAdjustment = XamlRoot.RasterizationScale;

            var x = (int)(AppTitleBar.Margin.Left * scaleAdjustment);
            var y = 0;
            var width = (int)(AppTitleBar.ActualWidth * scaleAdjustment);
            var height = (int)(48 * scaleAdjustment);

            var dragRect = new RectInt32(x, y, width, height);
            App.MainWindow.AppWindow.TitleBar.SetDragRectangles(new[] { dragRect });
        }

        private void MainNav_Loaded(object sender, RoutedEventArgs e)
        {
            _XamlRoot = XamlRoot;

            App.MainWindow.SetTitleBar(AppTitleBar);
            MainFrame.Navigate(typeof(Pages.Games.HonkaiImpact3.Container));

            RefreshDragArea();
            
        }

        private void MainNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (((NavigationViewItem)args.InvokedItemContainer).Tag.ToString() == "Settings")
                MainFrame.Navigate(typeof(Pages.Setting));
            else MainFrame.Navigate(Type.GetType("YoHoLauncher.Views.Pages.Games."
                                    + ((NavigationViewItem)args.InvokedItemContainer).Tag.ToString()
                                    + ".Container"));

        }

        private void MainNav_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (NavigationViewItem item in MainNav.MenuItems.Union(MainNav.FooterMenuItems).Cast<NavigationViewItem>())
            {
                if (item.Tag.ToString() == "Settings")
                {
                    if (typeof(Pages.Setting) == e.SourcePageType)
                    {
                        MainNav.SelectedItem = item;
                        item.IsSelected = true;
                        return;
                    }
                }
                else
                {
                    if (Type.GetType("YoHoLauncher.Views.Pages.Games."
                                    + item.Tag.ToString()
                                    + ".Container") == e.SourcePageType)
                    {
                        MainNav.SelectedItem = item;
                        item.IsSelected = true;
                        return;
                    }
                }
            }
        }
    }
}
