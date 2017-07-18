using System;
using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Events
{
    /// <summary></summary>
    internal sealed class EventMessageRouter : IEventMessageRouter
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="EventMessageRouter"/> class.</summary>
        /// <param name="handlerFactory">The <see cref="IEventHandlerFactory"/> object used to create new event handlers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handlerFactory"/> is <c>null</c>.</exception>
        public EventMessageRouter(IEventHandlerFactory handlerFactory)
        {
            if (handlerFactory == null)
            {
                throw new ArgumentNullException(nameof(handlerFactory));
            }

            Factory = handlerFactory;
        }
        #endregion

        #region Public Properties
        /// <summary>Gets the <see cref="IEventHandlerFactory"/> object used by the current instance to create new event handlers.</summary>
        /// <returns>The <see cref="IEventHandlerFactory"/> used by the current instance.</returns>
        public IEventHandlerFactory Factory { get; private set; }
        #endregion

        #region Public Method(s)
        /// <summary>Raises the specified event asynchronously.</summary>
        /// <param name="message">The <see cref="IEventMessage"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        public Task RaiseAsync(IEventMessage message, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var handlers = Factory.CreateHandlersFor(message);

                if (handlers != null)
                {
                    Parallel.ForEach(handlers, (handler) =>
                    {
                        try
                        {
                            handler.HandleAsync(message, cancellationToken);
                        }
                        finally
                        {
                            Factory.Release(handler);
                        }
                    });
                }
            });
        }
        #endregion
    }
}
