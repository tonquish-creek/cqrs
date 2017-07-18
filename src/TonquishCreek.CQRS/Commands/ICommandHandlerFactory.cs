namespace TonquishCreek.CQRS.Commands
{
    /// <summary>Provides methods for creating new command handlers.</summary>
    internal interface ICommandHandlerFactory
    {
        #region Method(s)
        /// <summary>Returns the message handler used to process the specified message.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to process.</param>
        /// <returns>An <see cref="ICommandHandler{TMessage}"/> object representing the handler that processes the message; otherwise, <c>null</c>.</returns>
        ICommandHandler<TMessage> CreateHandlerFor<TMessage>(TMessage message)
            where TMessage : ICommandMessage;

        /// <summary>Releases the specified handler which allows reuse of an existing instance of the handler depending on its lifestyle.</summary>
        /// <param name="handler">The <see cref="ICommandHandler{TMessage}"/> object to release.</param>
        void Release<TMessage>(ICommandHandler<TMessage> handler)
            where TMessage : ICommandMessage;
        #endregion
    }
}
