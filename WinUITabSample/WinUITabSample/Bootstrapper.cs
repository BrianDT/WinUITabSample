// <copyright file="Bootstrapper.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022. All rights reserved</copyright>

namespace WinUITabSample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;
    using Unity.Lifetime;
    using UnityDIFacade;
    using Vssl.Samples.Framework;
    using Vssl.Samples.FrameworkInterfaces;
    using Vssl.VisualFramework.ServiceInterfaces;
    using Vssl.VisualFramework.Services;
    using Vssl.VisualFramework.UIServices;
    using WinUITabSample.Services.BackendServices;
    using WinUITabSample.Services.ServiceInterfaces;
    using WinUITabSample.View.Pages;
    using WinUITabSample.ViewInterfaces;
    using WinUITabSample.ViewModelInterfaces;
    using WinUITabSample.ViewModels;

    /// <summary>
    /// Bootstraps the DI
    /// </summary>
    internal class Bootstrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
        /// </summary>
        public Bootstrapper()
        {
        }

        /// <summary>
        /// Initialise the dependency injection and register the classes.
        /// </summary>
        public void BootStrap()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container, new ContainerControlledLifetimeManager());
            container.RegisterType<IDependencyResolver, UnityDI>(new ContainerControlledLifetimeManager());

            // Framework
            container.RegisterType<IDispatchOnUIThread, UIDispatcher>(new ContainerControlledLifetimeManager());

            // Services
            container.RegisterType<IMessageService, MessageService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPagePresenter, PagePresenter>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILogging, LoggingService>(new ContainerControlledLifetimeManager());

            // View models
            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<IHomeViewModel, HomeViewModel>();
            container.RegisterType<ISettingsViewModel, SettingsViewModel>();
            container.RegisterType<IContentViewModel, ContentViewModel>();
            container.RegisterType<IItemsListViewModel, ItemsListViewModel>();
            container.RegisterType<IItemsList2ViewModel, ItemsList2ViewModel>();

            // Views
            container.RegisterType<IHomePage, WPage>();
            container.RegisterType<IT1Page, T1Page>();
            container.RegisterType<IT2Page, T2Page>();
            container.RegisterType<ICPage, CPage>();
            container.RegisterType<IS1Page, S1Page>();
            container.RegisterType<IS2Page, S2Page>();
            container.RegisterType<ILH1Page, LH1Page>();
            container.RegisterType<ILH2Page, LH2Page>();

            var diFacade = container.Resolve<IDependencyResolver>();
            var dispatcher = container.Resolve<IDispatchOnUIThread>();
            var presenter = container.Resolve<IPagePresenter>();

            presenter.Register(typeof(WPage), typeof(IHomeViewModel));
            presenter.Register(typeof(T1Page), typeof(IContentViewModel));
            presenter.Register(typeof(T2Page), typeof(IContentViewModel));
            presenter.Register(typeof(CPage), typeof(IContentViewModel));
            presenter.Register(typeof(S1Page), typeof(ISettingsViewModel));
            presenter.Register(typeof(S2Page), typeof(ISettingsViewModel));
            presenter.Register(typeof(LH1Page), typeof(IItemsListViewModel));
            presenter.Register(typeof(LH2Page), typeof(IItemsList2ViewModel));

            DependencyHelper.Container = diFacade;
            DispatchHelper.Initialise(dispatcher);
        }
    }
}
