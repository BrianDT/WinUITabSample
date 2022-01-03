// <copyright file="Item.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinUITabSample.ViewModelInterfaces;

    /// <summary>
    /// An item in a display list.
    /// </summary>
    public class Item : IItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class
        /// </summary>
        /// <param name="name">The name</param>
        public Item(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }
    }
}
