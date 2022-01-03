// <copyright file="IPresenterLoadedViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.ViewModelInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Common base interface on all view models
    /// </summary>
    public interface IPresenterLoadedViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Override method called when the view model is loaded
        /// </summary>
        /// <returns>The async task that can be awaited</returns>
        Task OnLoad();

        /// <summary>
        /// Override method called when the view model is unloaded
        /// </summary>
        /// <returns>The async task that can be awaited</returns>
        Task OnUnload();

        /// <summary>
        /// Called when the page referencing the view model is navigated to
        /// After the datacontext has been set.
        /// </summary>
        /// <param name="navigationParameters">The optional n avigation parameters</param>
        void OnNavigatedTo(object navigationParameters);
    }
}
