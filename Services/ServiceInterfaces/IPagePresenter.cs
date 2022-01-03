// <copyright file="IPagePresenter.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
#if !NETFX_CORE && !PORTABLE
    using System.Windows;
#endif

#if NETFX_CORE
    using Windows.UI.Xaml;
#endif

    /// <summary>
    /// Interface to the page presenter
    /// </summary>
    public interface IPagePresenter
    {
        /// <summary>
        /// Add a page and view model interface type pair to the index
        /// </summary>
        /// <param name="pageType">The type of the view page</param>
        /// <param name="viewModelInterface">The type of the view model interface</param>
        void Register(Type pageType, Type viewModelInterface);

        /// <summary>
        /// Find view model interface type in the registry given the page type.
        /// </summary>
        /// <param name="pageType">The type of the view page</param>
        /// <returns>The type of the matching view model interface</returns>
        Type Resolve(Type pageType);

        /// <summary>
        /// Find the view model data context based on the key provided and the mappings in the presenter
        /// </summary>
        /// <param name="sourcePageType">The type of the destination page</param>
        /// <param name="key">The context key</param>
        /// <returns>The view model</returns>
        INotifyPropertyChanged LocateDataContext(Type sourcePageType, Guid key);

        /// <summary>
        /// Find the view model data context based on the key provided and the view model interface.
        /// </summary>
        /// <param name="viewModelInterface">The type view model interface</param>
        /// <param name="key">The context key</param>
        /// <returns>The view model</returns>
        INotifyPropertyChanged LoadDataContext(Type viewModelInterface, Guid key);

        /*
        /// <summary>
        /// Caches the view model associated with the given key
        /// </summary>
        /// <param name="viewmodelType">The type of the view model</param>
        /// <param name="key">The key</param>
        /// <param name="viewmodel">The view model</param>
        void Cache(Type viewmodelType, Guid key, IViewModelBase viewmodel);

        /// <summary>
        /// Un-caches the view model for the requested key
        /// </summary>
        /// <param name="viewmodelType">The type of the view model</param>
        /// <param name="key">The key</param>
        /// <returns>The view model if one was present or null</returns>
        IViewModelBase UnCache(Type viewmodelType, Guid key);
         * */
    }
}
