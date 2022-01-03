// <copyright file="ItemsListViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

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
    public class ItemsListViewModel : BaseViewModel, IItemsListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsListViewModel"/> class
        /// </summary>
        public ItemsListViewModel()
        {
            List<IItem> items = new List<IItem>();
            items.Add(new Item("A0005"));
            items.Add(new Item("B0005"));
            items.Add(new Item("C0005"));
            items.Add(new Item("D0005"));
            items.Add(new Item("E0005"));
            items.Add(new Item("F0005"));
            items.Add(new Item("G0005"));
            this.Items = new ObservableCollection<IItem>(items);
        }

        /// <summary>
        /// Gets the collection of items.
        /// </summary>
        public ObservableCollection<IItem> Items { get; private set; }
    }
}
