// <copyright file="INavigationService.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

#if SILVERLIGHT
    using System.Windows.Navigation;
    using System.Windows;
    using System.Windows.Controls;
#elif NETFX_CORE
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
#endif

    /// <summary>
    /// Interface to the navigation service
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// An event used to request navigation in a non frames environment
        /// </summary>
        event BlockNavigationEventHandler NavitageRequest;

        /// <summary>
        /// Gets a value indicating whether it is possible to go back
        /// </summary>
        bool CanGoBack { get; }

#if SILVERLIGHT
        /// <summary>
        /// Initialises the page frame in the service
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        void Initialise(object sender, NavigationEventArgs e);
#elif NETFX_CORE
        /// <summary>
        /// Initialises the page frame in the service
        /// </summary>
        /// <param name="frame">The navigation frame</param>
        void Initialise(Frame frame);
#elif PORTABLE || NETSTANDARD1_4 || NETSTANDARD2_0 || NET5_0 || NET6_0
        /// <summary>
        /// Initialises the page frame in the service
        /// </summary>
        /// <param name="frame">The navigation frame</param>
        /// <param name="setDataContextOnNavigation">True if the data context will be set on navigation to the page</param>
        void Initialise(object frame, bool setDataContextOnNavigation = true);

        /// <summary>
        /// Add a secondary navigation frame
        /// </summary>
        /// <param name="frameNo">The frame no</param>
        /// <param name="frame">The navigation frame</param>
        void AddSecondaryPanel(int frameNo, object frame);

        /// <summary>
        /// Navigates to a new page given the interface type in a secondary frame
        /// </summary>
        /// <param name="frameNo">The navigation frame to use</param>
        /// <param name="interfaceType">The interface type</param>
        /// <param name="context">Contextual data associated with the navigation</param>
        /// <param name="transitionInfo">Optional transition information</param>
        /// <returns>True if navigated OK</returns>
        bool NavigateSecondary(int frameNo, Type interfaceType, object context, object transitionInfo = null);
#endif

#if !NETFX_CORE
        /////// <summary>
        /////// A helper function that sets the theme via the navigation servivce frame
        /////// </summary>
        /////// <param name="useDarkTheme">Sets the dark theme if true, if null use the default</param>
        ////void SetTheme(bool? useDarkTheme);
#endif

        /// <summary>
        /// Navigates to a new page given the interface type
        /// </summary>
        /// <param name="interfaceType">The interface type</param>
        /// <param name="context">Contextual data associated with the navigation</param>
        /// <param name="transitionInfo">Optional transition information</param>
        /// <returns>True if navigated OK</returns>
        Task<bool> Navigate(Type interfaceType, object context, object transitionInfo = null);

        /// <summary>
        /// Navigates to a new modal page given the interface type
        /// </summary>
        /// <param name="interfaceType">The interface type</param>
        /// <param name="context">Contextual data associated with the navigation</param>
        /// <param name="callbackCode">An optional callback code used if the target will return results</param>
        /// <returns>True if navigated OK</returns>
        Task<bool> NavigateModal(Type interfaceType, object context, int? callbackCode);

        /// <summary>
        /// Navigates to an external page
        /// </summary>
        /// <param name="targetUri">The URI to navigate to</param>
        /// <returns>The async task that can be awaited</returns>
        Task ExternalPageNavigation(Uri targetUri);

        /// <summary>
        /// Invoked as an event handler to navigate backward in the navigation stack
        /// associated with this page's <see cref="Frame"/>.
        /// </summary>
        /// <returns>An awaitable task</returns>
        Task GoBack();

        /// <summary>
        /// Invoked as an event handler to navigate backward in the page's associated
        /// <see cref="Frame"/> until it reaches the top of the navigation stack.
        /// </summary>
        /// <returns>An awaitable task</returns>
        Task GoHome();

        /// <summary>
        /// Gets the viewm odel of a given type of view model interface
        /// </summary>
        /// <param name="viewModelInterfaceType">The type of the view model interface</param>
        /// <param name="key">The context key - if set used for caching</param>
        /// <returns>The view model</returns>
        INotifyPropertyChanged GetViewModelForInterface(Type viewModelInterfaceType, Guid key);
    }
}
