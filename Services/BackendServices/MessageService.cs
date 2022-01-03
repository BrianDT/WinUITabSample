// <copyright file="MessageService.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022. All rights reserved</copyright>

namespace WinUITabSample.Services.BackendServices
{
    using WinUITabSample.Services.ServiceInterfaces;

    /// <summary>
    /// The message service
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <summary>
        /// Notifies that a new message has been received
        /// </summary>
        public event EventHandler NewMessage;

        /// <summary>
        /// Notify a message to the service
        /// </summary>
        /// <param name="messge">The message</param>
        public void Notify(string messge)
        {
        }
    }
}