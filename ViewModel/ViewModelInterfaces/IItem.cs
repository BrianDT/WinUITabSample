// <copyright file="IItem.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModelInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// An item in a display list.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }
    }
}
