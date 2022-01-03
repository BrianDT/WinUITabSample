// <copyright file="IPageViewModelBase.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModelInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Vssl.Samples.ViewModelInterfaces;

    /// <summary>
    /// The view model for the base class for navigabble page view models.
    /// </summary>
    public interface IPageViewModelBase : IBaseViewModel
    {
        /// <summary>
        /// Navigate the the page identified by the tag string.
        /// </summary>
        /// <param name="navItemTag">The navigation tab tag</param>
        /// <param name="transitionInfo">Optional transition information</param>
        void NavigateToPage(string navItemTag, object transitionInfo);

        /// <summary>
        /// Record a navigation failure.
        /// </summary>
        /// <param name="name">The name of the page</param>
        void NavigationFailed(string name);
    }
}
