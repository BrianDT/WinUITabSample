// <copyright file="IInitialisable.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.ViewModelInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for view modules that can be initialised with a identifier.
    /// </summary>
    public interface IInitialisable
    {
        /// <summary>
        /// Gets the identifier passed to the view model.
        /// </summary>
        Guid Identifier { get; }

        /// <summary>
        /// Initialises the model.
        /// </summary>
        /// <param name="modelIdentifier">The identifier of the model the view model is based on.</param>
        void OnInitialise(Guid modelIdentifier);
    }
}
