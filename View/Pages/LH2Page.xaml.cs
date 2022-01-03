// <copyright file="LH2Page.xaml.cs" company="Visual Software Systems Ltd.">
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
    public sealed partial class LH2Page : Page, ILH2Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LH2Page"/> class
        /// Note DataContext is populated by the presenter on navigation.
        /// </summary>
        public LH2Page()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the viewmodel as an interface.
        /// </summary>
        public IItemsList2ViewModel VM => this.DataContext as IItemsList2ViewModel;
    }
}
