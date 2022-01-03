// <copyright file="IMessageService.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022. All rights reserved</copyright>

namespace WinUITabSample.Services.ServiceInterfaces
{
    /// <summary>
    /// The message service
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Notifies that a new message has been received
        /// </summary>
        event EventHandler NewMessage;

        /// <summary>
        /// Notify a message to the service
        /// </summary>
        /// <param name="messge">The message</param>
        void Notify(string messge);
    }
}