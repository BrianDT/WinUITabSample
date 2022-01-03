// <copyright file="PagePresenter.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Vssl.Samples.FrameworkInterfaces;
    using Vssl.VisualFramework.ServiceInterfaces;
    using Vssl.VisualFramework.ViewModelInterfaces;
    using WinUITabSample.Services.ServiceInterfaces;

    /// <summary>
    /// Controls the mapping between pages and their view models.
    /// </summary>
    public class PagePresenter : IPagePresenter
    {
        #region [ Private fields ]

        /// <summary>
        /// The dependency injection resolution helper.
        /// </summary>
        private IDependencyResolver dependencyResolver;

        /// <summary>
        /// Interface to the logging service.
        /// </summary>
        private ILogging loggingService;

        /// <summary>
        /// The index of pages and view model interface types.
        /// </summary>
        private Dictionary<Type, Type> registery;

        /// <summary>
        /// The index of populated view models.
        /// </summary>
        private Dictionary<Type, Dictionary<Guid, INotifyPropertyChanged>> populatedViewModels;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="PagePresenter"/> class
        /// </summary>
        /// <param name="dependencyResolver">The dependency injection resolution helper</param>
        /// <param name="loggingService">Interface to the logging service</param>
        public PagePresenter(IDependencyResolver dependencyResolver, ILogging loggingService)
        {
            this.dependencyResolver = dependencyResolver;
            this.loggingService = loggingService;
            this.registery = new Dictionary<Type, Type>();
            this.populatedViewModels = new Dictionary<Type, Dictionary<Guid, INotifyPropertyChanged>>();
        }

        #endregion

        /// <summary>
        /// Add a page and view model interface type pair to the index.
        /// </summary>
        /// <param name="pageType">The type of the view page</param>
        /// <param name="viewModelInterface">The type of the view model interface</param>
        public void Register(Type pageType, Type viewModelInterface)
        {
            this.registery.Add(pageType, viewModelInterface);
        }

        /// <summary>
        /// Find view model interface type in the registry given the page type.
        /// </summary>
        /// <param name="pageType">The type of the view page</param>
        /// <returns>The type of the matching view model interface</returns>
        public Type Resolve(Type pageType)
        {
            if (this.registery.ContainsKey(pageType))
            {
                return this.registery[pageType];
            }

            return null;
        }

        /// <summary>
        /// Find the view model data context based on the key provided and the mappings in the presenter
        /// </summary>
        /// <param name="sourcePageType">The type of the destination page</param>
        /// <param name="key">The context key</param>
        /// <returns>The view model</returns>
        public INotifyPropertyChanged LocateDataContext(Type sourcePageType, Guid key)
        {
            Type viewModelInterface = this.Resolve(sourcePageType);
            return this.LoadDataContext(viewModelInterface, key);
        }

        /// <summary>
        /// Find the view model data context based on the key provided and the view model interface.
        /// </summary>
        /// <param name="viewModelInterface">The type view model interface</param>
        /// <param name="key">The context key</param>
        /// <returns>The view model</returns>
        public INotifyPropertyChanged LoadDataContext(Type viewModelInterface, Guid key)
        {
            // Check for an existing viewmodel that matches this content
            INotifyPropertyChanged viewModel = this.UnCache(viewModelInterface, key);
            if (viewModel == null)
            {
                try
                {
                    viewModel = this.dependencyResolver.Resolve(viewModelInterface) as INotifyPropertyChanged;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                if (viewModel != null)
                {
                    // Prep the view model
                    if (key != Guid.Empty)
                    {
                        IInitialisable initialisableViewModel = viewModel as IInitialisable;
                        if (initialisableViewModel != null)
                        {
                            initialisableViewModel.OnInitialise(key);
                        }
                    }

                    // Cache the viewmodel
                    this.Cache(viewModelInterface, key, viewModel);
                }
                else
                {
                    var message = $"No viewmodel mapped to type {viewModelInterface.FullName}";
                    Debug.WriteLine(message);
                    this.loggingService.AuditEvent(message, 64);
                }
            }

            return viewModel;
        }

        #region [ Private Methods ]

        /// <summary>
        /// Caches the view model associated with the given key
        /// </summary>
        /// <param name="viewmodelType">The type of the view model</param>
        /// <param name="key">The key</param>
        /// <param name="viewmodel">The view model</param>
        private void Cache(Type viewmodelType, Guid key, INotifyPropertyChanged viewmodel)
        {
            Dictionary<Guid, INotifyPropertyChanged> viewModelsForType = null;
            if (this.populatedViewModels.ContainsKey(viewmodelType))
            {
                viewModelsForType = this.populatedViewModels[viewmodelType];
            }
            else
            {
                viewModelsForType = new Dictionary<Guid, INotifyPropertyChanged>();
                this.populatedViewModels.Add(viewmodelType, viewModelsForType);
            }

            viewModelsForType.Add(key, viewmodel);

            ////IHints viewModelWithHints = viewmodel as IHints;
            ////if (viewModelWithHints != null)
            ////{
            ////    viewModelWithHints.UseTipsAndHints = PagePresenter.TipsAndHints;
            ////}
        }

        /// <summary>
        /// Un-caches the view model for the requested key
        /// </summary>
        /// <param name="viewmodelType">The type of the view model</param>
        /// <param name="key">The key</param>
        /// <returns>The view model if one was present or null</returns>
        private INotifyPropertyChanged UnCache(Type viewmodelType, Guid key)
        {
            if (this.populatedViewModels.ContainsKey(viewmodelType))
            {
                Dictionary<Guid, INotifyPropertyChanged> viewModelsForType = this.populatedViewModels[viewmodelType];
                if (viewModelsForType.ContainsKey(key))
                {
                    return viewModelsForType[key];
                }
            }

            return null;
        }

        #endregion
    }
}
