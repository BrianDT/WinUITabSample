// <copyright file="HomeViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Vssl.Samples.ViewModels;
    using WinUITabSample.ViewModelInterfaces;

    /// <summary>
    /// View model for the home page.
    /// </summary>
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class
        /// </summary>
        public HomeViewModel()
        {
        }
    }
}
