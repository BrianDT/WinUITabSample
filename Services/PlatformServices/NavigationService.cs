// <copyright file="NavigationService.cs" company="Visual Software Systems Ltd.">Copyright (c) 2012 All rights reserved</copyright>

namespace Vssl.VisualFramework.UIServices
{
    using System;
    using System.Collections.Generic;
#if !NETFX_CORE && !PORTABLE && !HAS_UNO && !NET5_0 && !NET6_0
    using System.Diagnostics;
#endif
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
#if !NETFX_CORE && !PORTABLE && !XAMARIN && !HAS_UNO && !NET5_0 && !NET6_0
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Xaml;
#endif

#if !NETFX_CORE && !SILVERLIGHT && !PORTABLE && !XAMARIN && !HAS_UNO && !NET5_0 && !NET6_0
    using Vssl.VisualFramework.Common;
#endif
    using Vssl.VisualFramework.ServiceInterfaces;
    using Vssl.VisualFramework.ViewInterfaces;
    using Vssl.VisualFramework.ViewModelInterfaces;

#if NETFX_CORE || PORTABLE
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using System.ComponentModel;
#elif NET5_0 || NET6_0 || HAS_UNO
    using System.ComponentModel;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media.Animation;
    using Microsoft.UI.Xaml.Navigation;
    using Vssl.Samples.FrameworkInterfaces;
#endif

#if XAMARIN
    using Xamarin.Forms;
#endif

    /// <summary>
    /// Navigates between pages
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The navigation frame
        /// </summary>
#if XAMARIN
        private NavigationPage frame;
#else
        private Frame frame;

        private Dictionary<int, Frame> secondaryFrames = new Dictionary<int, Frame>();
#endif

        /// <summary>
        /// The dependency injection resolution helper
        /// </summary>
        private IDependencyResolver dependencyResolver;

        /// <summary>
        /// The page presenter
        /// </summary>
        private IPagePresenter presenter;

        /// <summary>
        /// A value indicating whether the data context will be set on navigation to the page.
        /// </summary>
        private bool setDataContextOnNavigation;

#if SILVERLIGHT
        private System.Windows.Navigation.NavigationService windowsNavigationService;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class
        /// </summary>
        /// <param name="dependencyResolver">The dependency injection resolution helper</param>
        /// <param name="presenter">The presenter to use</param>
        public NavigationService(IDependencyResolver dependencyResolver, IPagePresenter presenter)
        {
            this.dependencyResolver = dependencyResolver;
            this.presenter = presenter;
        }

        /// <summary>
        /// An event used to request navigation in a non frames environment
        /// </summary>
        public event BlockNavigationEventHandler NavitageRequest;

        /// <summary>
        /// Gets a value indicating whether it is possible to go back
        /// </summary>
        public bool CanGoBack
        {
            get
            {
#if XAMARIN
                return false;
#else
                return this.frame != null && this.frame.CanGoBack;
#endif
            }
        }

#if SILVERLIGHT
        /// <summary>
        /// Initialises the page frame in the service
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        public void Initialise(object sender, NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            if (page != null)
            {
                this.windowsNavigationService = page.NavigationService;
            }

            this.windowsNavigationService.Navigated += this.OnNavigated;

            this.OnNavigated(sender, e);
        }
////#elif NETFX_CORE && !HYBRID
////        /// <summary>
////        /// Initialises the page frame in the service
////        /// </summary>
////        /// <param name="frame">The navigation frame</param>
////        public void Initialise(Frame frame)
////        {
////            this.frame = frame;
////            frame.Navigated += this.OnNavigated;
////        }
#elif NETFX_CORE || PORTABLE || HYBRID || HAS_UNO || NET5_0 || NET6_0
        /// <summary>
        /// Initialises the page frame in the service
        /// </summary>
        /// <param name="frame">The navigation frame</param>
        /// <param name="setDataContextOnNavigation">True if the data context will be set on navigation to the page</param>
        public void Initialise(object frame, bool setDataContextOnNavigation = true)
        {
            this.frame = (Frame)frame;
            this.setDataContextOnNavigation = setDataContextOnNavigation;
            this.frame.Navigated += this.OnNavigated;
        }

        /// <summary>
        /// Add a secondary navigation frame
        /// </summary>
        /// <param name="frameNo">The frame no</param>
        /// <param name="frame">The navigation frame</param>
        public void AddSecondaryPanel(int frameNo, object frame)
        {
            this.secondaryFrames[frameNo] = (Frame)frame;
            this.secondaryFrames[frameNo].Navigated += this.OnNavigated;
        }

        /// <summary>
        /// Navigates to a new page given the interface type in a secondary frame
        /// </summary>
        /// <param name="frameNo">The navigation frame to use</param>
        /// <param name="interfaceType">The interface type</param>
        /// <param name="context">Contextual data associated with the navigation</param>
        /// <param name="transitionInfo">Optional transition information</param>
        /// <returns>True if navigated OK</returns>
        public bool NavigateSecondary(int frameNo, Type interfaceType, object context, object transitionInfo = null)
        {
            Frame secondaryFrame;
            if (this.secondaryFrames.TryGetValue(frameNo, out secondaryFrame))
            {
                if (secondaryFrame != null)
                {
                    Type view = this.dependencyResolver.GetMappedType(interfaceType);

                    // Get the page type before navigation so you can prevent duplicate
                    // entries in the backstack.
                    var preNavPageType = secondaryFrame.CurrentSourcePageType;

                    // Only navigate if the selected page isn't currently loaded.
                    if (!(view is null) && !Type.Equals(preNavPageType, view))
                    {
                        return secondaryFrame.Navigate(view, context, transitionInfo as NavigationTransitionInfo);
                    }
                }
            }

            return false;
        }

#elif XAMARIN
        /// <summary>
        /// Initialises the page frame in the service
        /// </summary>
        /// <param name="frame">The navigation frame</param>
        public void Initialise(object frame)
        {
            this.frame = (NavigationPage)frame;
        }
#endif

        /// <summary>
        /// Navigates to a new page given the interface type
        /// </summary>
        /// <param name="interfaceType">The interface type</param>
        /// <param name="context">Contextual data associated with the navigation</param>
        /// <param name="transitionInfo">Optional transition information</param>
        /// <returns>True if navigated OK</returns>
        public async Task<bool> Navigate(Type interfaceType, object context, object transitionInfo = null)
        {
            Type view = this.dependencyResolver.GetMappedType(interfaceType);
            if (this.frame != null)
            {
#if SILVERLIGHT
                string url = null; // Get fromn the mapping
                Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
                return this.windowsNavigationService.Navigate(uri);
#elif XAMARIN
                Page page = (Page)this.container.Resolve(view);
                await this.frame.Navigation.PushAsync(page);
#else
                // Get the page type before navigation so you can prevent duplicate
                // entries in the backstack.
                var preNavPageType = this.frame.CurrentSourcePageType;

                // Only navigate if the selected page isn't currently loaded.
                if (!(view is null) && !Type.Equals(preNavPageType, view))
                {
                    return this.frame.Navigate(view, context, transitionInfo as NavigationTransitionInfo);
                }
#endif
            }
            else if (this.NavitageRequest != null)
            {
                Type viewModelInterface = this.presenter.Resolve(view);

                BlockNavigationEventHandler threadSafeCopy = this.NavitageRequest;
                BlockNavigationEventArgs args = new BlockNavigationEventArgs(viewModelInterface, context);
                threadSafeCopy(this, args);

                return true;
            }

#if NETFX_CORE || HAS_UNO || NET5_0 || NET6_0
            return await Task.FromResult(false);
#else
            return false;
#endif
        }

        /// <summary>
        /// Navigates to a new modal page given the interface type
        /// </summary>
        /// <param name="interfaceType">The interface type</param>
        /// <param name="context">Contextual data associated with the navigation</param>
        /// <param name="callbackCode">An optional callback code used if the target will return results</param>
        /// <returns>True if navigated OK</returns>
        public async Task<bool> NavigateModal(Type interfaceType, object context, int? callbackCode)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Navigates to an external page
        /// </summary>
        /// <param name="targetUri">The URI to navigate to</param>
        /// <returns>The async task that can be awaited</returns>
        public async Task ExternalPageNavigation(Uri targetUri)
        {
#if WINDOWS_PHONE
            WebBrowserTask wbtask = new WebBrowserTask();
            wbtask.Uri = targetUri;
            wbtask.Show();
#elif NETFX_CORE || PORTABLE || HAS_UNO || NET5_0 || NET6_0
            await Windows.System.Launcher.LaunchUriAsync(targetUri);
#elif SILVERLIGHT
            System.Windows.Browser.HtmlPage.Window.Navigate(targetUri, "_blank");
#else
            Process.Start(new ProcessStartInfo(targetUri.ToString()));
#endif
            return;
        }

        /// <summary>
        /// Invoked as an event handler to navigate backward in the page's associated
        /// <see cref="Frame"/> until it reaches the top of the navigation stack.
        /// </summary>
        /// <returns>An awaitable task</returns>
        public async Task GoHome()
        {
#if XAMARIN
            await this.frame.Navigation.PopToRootAsync();

#else
            // Use the navigation frame to return to the topmost page
            if (this.frame != null)
            {
                while (this.frame.CanGoBack)
                {
                    this.frame.GoBack();
                }
            }
#endif
#if NETFX_CORE || HAS_UNO || NET5_0 || NET6_0
            await Task.CompletedTask;
#endif
        }

        /// <summary>
        /// Invoked as an event handler to navigate backward in the navigation stack
        /// associated with this page's <see cref="Frame"/>.
        /// </summary>
        /// <returns>An awaitable task</returns>
        public async Task GoBack()
        {
#if XAMARIN
            await this.frame.Navigation.PopAsync();
#else
            // Use the navigation frame to return to the previous page
            if (this.frame != null && this.frame.CanGoBack)
            {
                this.frame.GoBack();
            }
#endif
#if NETFX_CORE || HAS_UNO || NET5_0 || NET6_0
            await Task.CompletedTask;
#endif
        }

        /// <summary>
        /// Invoked as an event handler to navigate forward in the navigation stack
        /// associated with this page's <see cref="Frame"/>.
        /// </summary>
        public void GoForward()
        {
#if XAMARIN
            throw new NotImplementedException();
#else
            // Use the navigation frame to move to the next page
            if (this.frame != null && this.frame.CanGoForward)
            {
                this.frame.GoForward();
            }
#endif
        }

#if !NETFX_CORE
        /////// <summary>
        /////// A helper function that sets the theme via the navigation servivce frame
        /////// </summary>
        /////// <param name="useDarkTheme">Sets the dark theme if true, if null use the default</param>
        ////public void SetTheme(bool? useDarkTheme)
        ////{
        ////    if (useDarkTheme.HasValue)
        ////    {
        ////        this.frame.RequestedTheme = useDarkTheme.Value ? ElementTheme.Dark : ElementTheme.Light;
        ////    }
        ////    else
        ////    {
        ////        this.frame.RequestedTheme = ElementTheme.Default;
        ////    }
        ////}
#endif

        /// <summary>
        /// Gets the viewm odel of a given type of view model interface
        /// </summary>
        /// <param name="viewModelInterfaceType">The type of the view model interface</param>
        /// <param name="key">The context key - if set used for caching</param>
        /// <returns>The view model</returns>
        public INotifyPropertyChanged GetViewModelForInterface(Type viewModelInterfaceType, Guid key)
        {
            var viewModel = this.presenter.LoadDataContext(viewModelInterfaceType, key);
            return viewModel;
        }
#if !XAMARIN
        /// <summary>
        /// Navigated event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            if (page != null)
            {
                INavigablePageBase vsslPage = page as INavigablePageBase;
                if (vsslPage != null)
                {
                    Guid key = Guid.Empty;
                    object navigationParameters = null;
#if NETFX_CORE || PORTABLE || HAS_UNO || NET5_0 || NET6_0
                    Type sourcePageType = e.SourcePageType;
                    if (e.Parameter != null)
                    {
                        if (e.Parameter is Guid)
                        {
                            key = (Guid)e.Parameter;
                        }
                        else if (typeof(INavigationData).IsAssignableFrom(e.Parameter.GetType()))
                        {
                            key = ((INavigationData)e.Parameter).Key;
                            navigationParameters = ((INavigationData)e.Parameter).Parameters;
                        }
                        else
                        {
                            navigationParameters = e.Parameter;
                        }
                    }
#elif SILVERLIGHT
                    Type sourcePageType = page.GetType();
#else
                    Type sourcePageType = null;
                    if (e.ExtraData != null)
                    {
                        NavigationData navigationData = e.ExtraData as NavigationData;
                        if (navigationData != null)
                        {
                            sourcePageType = navigationData.SourcePageType;
                            key = navigationData.Key;
                            navigationParameters = navigationData.Parameters;
                        }
                    }
#endif
                    INotifyPropertyChanged viewModel = null;
                    if (!this.setDataContextOnNavigation)
                    {
                        viewModel = page.DataContext as INotifyPropertyChanged;
                    }
                    else
                    {
                        viewModel = this.presenter.LocateDataContext(sourcePageType, key);

                        IUsesDynamicTemplates pageUsesDynamicTemplates = page as IUsesDynamicTemplates;
                        if (pageUsesDynamicTemplates != null)
                        {
                            pageUsesDynamicTemplates.DeferredViewModel = viewModel;
                        }
                        else
                        {
                            page.DataContext = viewModel;
                        }
                    }

                    var presenterVM = viewModel as IPresenterLoadedViewModel;
                    if (presenterVM != null)
                    {
                        presenterVM.OnNavigatedTo(navigationParameters);
                    }
                }
            }
        }
#endif
    }
}
