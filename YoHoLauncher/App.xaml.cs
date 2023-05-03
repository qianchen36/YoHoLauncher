﻿// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YoHoLauncher.Components;
using Microsoft.UI.Dispatching;
using System.Runtime.InteropServices;
using System.Threading;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace YoHoLauncher
{
    /// <summary>
    /// Boot without the default Application class.
    /// </summary>
    public partial class App
    {
        [DllImport("Microsoft.UI.Xaml.dll")]
        private static extern void XamlCheckProcessRequirements();

        [STAThread]
        static int Main(string[] args)
        {
            XamlCheckProcessRequirements();
            WinRT.ComWrappersSupport.InitializeComWrappers();

            Microsoft.UI.Xaml.Application.Start((p) =>
            {
                SynchronizationContext.SetSynchronizationContext(new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread()));
                new App();
            });

            return 0;
        }
    }

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainWindow { get; private set; }
        public static Configuration Configuration { get; private set; } = Configuration.Load();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            // Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = Configuration.CurrentLanguage;
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {            
            MainWindow = new MainWindow();
            MainWindow.Activate();
        }
    }
}
