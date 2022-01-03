// <copyright file="IUsesDynamicTemplates.cs" company="Visual Software Systems Ltd.">Copyright (c) 2014 All rights reserved</copyright>

namespace Vssl.VisualFramework.ViewInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used to indicate that the bindings need to be toggled on load.
    /// </summary>
    public interface IUsesDynamicTemplates
    {
        /// <summary>
        /// Gets or sets a viewmodel whos setting is deferred until load.
        /// </summary>
        object DeferredViewModel { get; set; }
    }
}
