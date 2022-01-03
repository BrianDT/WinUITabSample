// <copyright file="ILogging.cs" company="Visual Software Systems Ltd.">
// Copyright (c) 2012 - 2022. All rights reserved.
// </copyright>

namespace WinUITabSample.Services.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Cut down loggin service.
    /// </summary>
    public interface ILogging
    {
        /// <summary>
        /// Log an event.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="code">The code</param>
        void AuditEvent(string message, int code);
    }
}
