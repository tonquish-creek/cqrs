using System;
using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary></summary>
    internal sealed class CommandMessageRouter : ICommandMessageRouter
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="CommandMessageRouter"/> class.</summary>
        /// <param name="handlerFactory">The <see cref="ICommandHandlerFactory"/> object used to create new command handlers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handlerFactory"/> is <c>null</c>.</exception>
        public CommandMessageRouter(ICommandHandlerFactory handlerFactory)
        {
            if (handlerFactory == null)
            {
                throw new ArgumentNullException(nameof(handlerFactory));
            }

            Factory = handlerFactory;
        }
        #endregion

        #region Public Properties
        /// <summary>Gets the <see cref="ICommandHandlerFactory"/> object used by the current instance to create new command handlers.</summary>
        /// <returns>The <see cref="ICommandHandlerFactory"/> used by the current instance.</returns>
        public ICommandHandlerFactory Factory { get; private set; }
        #endregion

        #region Public Method(s)
        /// <summary>Sends the specified command asynchronously to the appropriate handler.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SendAsync(ICommandMessage message, CancellationToken cancellationToken)
        {
            var handler = Factory.CreateHandlerFor(message);

            try
            {
                return handler.HandleAsync(message, cancellationToken);
            }
            finally
            {
                Factory.Release(handler);
            }
        }
        #endregion
    }
}
