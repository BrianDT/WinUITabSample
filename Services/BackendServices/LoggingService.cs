// <copyright file="LoggingService.cs" company="Visual Software Systems Ltd.">
// Copyright (c) 2012 - 2022. All rights reserved.
// </copyright>

namespace WinUITabSample.Services.BackendServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinUITabSample.Services.ServiceInterfaces;

    /// <summary>
    /// Cut down loggin service.
    /// </summary>
    public class LoggingService : ILogging
    {
        /// <summary>
        /// Log an event.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="code">The code</param>
        public void AuditEvent(string message, int code)
        {
            // Not implementated in this sample
        }
    }
}
