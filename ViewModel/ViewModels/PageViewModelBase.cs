// <copyright file="PageViewModelBase.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Vssl.Samples.ViewModels;
    using Vssl.VisualFramework.ServiceInterfaces;
    using WinUITabSample.Services.ServiceInterfaces;

    /// <summary>
    /// The view model for the base class for navigabble page view models.
    /// </summary>
    public abstract class PageViewModelBase : BaseViewModel
    {
        /// <summary>
        /// The bottom bar message service.
        /// </summary>
        private IMessageService messageService;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewModelBase"/> class
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="messageService">The bottom bar message service.</param>
        public PageViewModelBase(INavigationService navigationService, IMessageService messageService)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
        }

        /// <summary>
        /// Gets the bottom bar message service.
        /// </summary>
        protected IMessageService MessageService => this.messageService;

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        protected INavigationService NavigationService => this.navigationService;

        /// <summary>
        /// Navigate the the page identified by the tag string.
        /// </summary>
        /// <param name="navItemTag">The navigation tab tag</param>
        /// <param name="transitionInfo">Optional transition information</param>
        public abstract void NavigateToPage(string navItemTag, object transitionInfo);

        /// <summary>
        /// Record a navigation failure.
        /// </summary>
        /// <param name="name">The name of the page</param>
        public void NavigationFailed(string name)
        {
            this.messageService.Notify("Failed to load Page " + name);
        }
    }
}
