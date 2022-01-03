// <copyright file="MainWindow.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022. All rights reserved</copyright>

namespace WinUITabSample
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Controls.Primitives;
    using Microsoft.UI.Xaml.Data;
    using Microsoft.UI.Xaml.Input;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Media.Animation;
    using Microsoft.UI.Xaml.Navigation;
    using Vssl.Samples.Framework;
    using Vssl.VisualFramework.ServiceInterfaces;
    using Windows.ApplicationModel.Core;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using WinUITabSample.Services.ServiceInterfaces;
    using WinUITabSample.View.Pages;
    using WinUITabSample.ViewInterfaces;
    using WinUITabSample.ViewModelInterfaces;

    // To learn more about WinUI, the WinUI project structure,
    // and more about our project templates, see: http://aka.ms/winui-project-info.

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.ExtendsContentIntoTitleBar = true;
            this.VM = DependencyHelper.Resolve<IMainViewModel>();
            this.navigationService = DependencyHelper.Resolve<INavigationService>();
            this.navigationService.Initialise(this.ContentFrame);
            this.navigationService.AddSecondaryPanel(1, this.LHContentFrame);

            this.Activated += (s, e) =>
            {
                if (this.ContentFrame.CurrentSourcePageType == null)
                {
                    this.VM.OnNavigatedTo(null);
                }
            };
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        public IMainViewModel VM { get; private set; }

        /// <summary>
        /// Extract the navigation tag and initiate a page navigation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event args.</param>
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string navItemTag = null;
            if (args.IsSettingsInvoked == true)
            {
                navItemTag = "navsettings";
            }
            else if (args.InvokedItemContainer != null)
            {
                navItemTag = args.InvokedItemContainer.Tag.ToString();
            }

            this.VM.NavigateToPage(navItemTag, args.RecommendedNavigationTransitionInfo);
        }

        /// <summary>
        /// Notify a navigation failure.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            this.VM.NavigationFailed(e.SourcePageType.FullName);
        }

        /// <summary>
        /// Toggle the Left Hand Panel display.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OpenLH_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.VM.ToggleLHPanel();
        }
    }
}
