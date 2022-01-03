// <copyright file="ItemsList2ViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Vssl.Samples.ViewModels;
    using WinUITabSample.ViewModelInterfaces;

    /// <summary>
    /// The view model for a page displaying a list ot items.
    /// </summary>
    public class ItemsList2ViewModel : BaseViewModel, IItemsList2ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsList2ViewModel"/> class
        /// </summary>
        public ItemsList2ViewModel()
        {
            List<IItem> items = new List<IItem>();
            items.Add(new Item("Fred"));
            items.Add(new Item("Joe"));
            items.Add(new Item("Bill"));
            items.Add(new Item("Sue"));
            this.Items = new ObservableCollection<IItem>(items);
        }

        /// <summary>
        /// Gets the collection of items.
        /// </summary>
        public ObservableCollection<IItem> Items { get; private set; }
    }
}
