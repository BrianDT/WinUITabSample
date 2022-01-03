// <copyright file="LH1Page.xaml.cs" company="Visual Software Systems Ltd.">
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
    using Vssl.Samples.Framework;
    using WinUITabSample.ViewInterfaces;
    using WinUITabSample.ViewModelInterfaces;

    // To learn more about WinUI, the WinUI project structure,
    // and more about our project templates, see: http://aka.ms/winui-project-info.

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LH1Page : Page, ILH1Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LH1Page"/> class
        /// Note DataContext is populated by the presenter on navigation.
        /// </summary>
        public LH1Page()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the viewmodel as an interface.
        /// </summary>
        public IItemsListViewModel VM => this.DataContext as IItemsListViewModel;
    }
}
