// <copyright file="WPage.xaml.cs" company="Visual Software Systems Ltd.">
// Copyright (c) 2012 - 2022. All rights reserved.
// </copyright>

namespace WinUITabSample.View.Pages
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
    using Microsoft.UI.Xaml.Navigation;
    using Vssl.Samples.Framework;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using WinUITabSample.ViewInterfaces;
    using WinUITabSample.ViewModelInterfaces;

    // To learn more about WinUI, the WinUI project structure,
    // and more about our project templates, see: http://aka.ms/winui-project-info.

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WPage : Page, IHomePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WPage"/> class
        /// Note DataContext is populated by the presenter on navigation.
        /// </summary>
        public WPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the viewmodel as an interface.
        /// </summary>
        public IHomeViewModel VM => this.DataContext as IHomeViewModel;

        ////private void ItemW_Tapped(object sender, TappedRoutedEventArgs e)
        ////{
        ////}
    }
}
