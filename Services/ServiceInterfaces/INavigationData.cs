// <copyright file="INavigationData.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace Vssl.VisualFramework.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The navigation data
    /// </summary>
    public interface INavigationData
    {
        /// <summary>
        /// Gets or sets the key of the data on the page being navigated to
        /// </summary>
        Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the type of the page being navigated to
        /// </summary>
        Type SourcePageType { get; set; }

        /// <summary>
        /// Gets or sets the optional navigation parameters
        /// </summary>
        object Parameters { get; set; }
    }

    /// <summary>
    /// The navigation data with generic parameters
    /// </summary>
    /// <typeparam name="T">The type of the parameters</typeparam>
    public interface INavigationData<T> : INavigationData
    {
        /// <summary>
        /// Gets or sets the optional navigation parameters
        /// </summary>
        new T Parameters { get; set; }
    }
}
