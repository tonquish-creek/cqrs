using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TonquishCreek.CQRS.Events
{
    /// <summary></summary>
    public interface IEventHandlerFactory : IDisposable
    {
        #region Method(s)
        /// <summary>Returns the handlers used to process the specified event message.</summary>
        /// <param name="message">The <see cref="IEventMessage"/> object to process.</param>
        /// <returns>A collection of <see cref="IEventHandler{TMessage}"/> objects representing the handlers that processes the message; otherwise, <c>null</c>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This signature is required by some IoC frameworks to automatically implement the factory.")]
        IEnumerable<IEventHandler<TMessage>> CreateHandlersFor<TMessage>(TMessage message)
            where TMessage : IEventMessage;

        /// <summary>Releases the specified handler which allows reuse of an existing instance of the handler depending on its lifestyle.</summary>
        /// <param name="handler">The <see cref="IEventHandler{TMessage}"/> object to release.</param>
        void Release<TMessage>(IEventHandler<TMessage> handler)
            where TMessage : IEventMessage;
        #endregion
    }
}
