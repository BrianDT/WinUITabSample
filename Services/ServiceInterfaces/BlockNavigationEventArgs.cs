// <copyright file="BlockNavigationEventArgs.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// An event handler that notifies registered views that a block navigation has been requested
    /// </summary>
    public class BlockNavigationEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockNavigationEventArgs"/> class
        /// </summary>
        /// <param name="target">The target type</param>
        /// <param name="context">The contextual navigation data</param>
        public BlockNavigationEventArgs(Type target, object context)
        {
            this.TargetView = target;
            this.ExtraData = context;
        }

        /// <summary>
        /// Gets the target type
        /// </summary>
        public Type TargetView
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the contextual navigation data
        /// </summary>
        public object ExtraData
        {
            get;
            private set;
        }
    }
}
