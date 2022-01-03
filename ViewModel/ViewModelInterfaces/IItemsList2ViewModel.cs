// <copyright file="IItemsList2ViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModelInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Vssl.Samples.ViewModelInterfaces;

    /// <summary>
    /// The view model for a page displaying a list ot items.
    /// </summary>
    public interface IItemsList2ViewModel : IBaseViewModel
    {
        /// <summary>
        /// Gets the collection of items.
        /// </summary>
        ObservableCollection<IItem> Items { get; }
    }
}
