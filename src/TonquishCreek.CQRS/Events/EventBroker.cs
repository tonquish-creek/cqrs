using System;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Events
{
    /// <summary></summary>
    public sealed class EventBroker : IEventBroker
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="EventBroker"/> class.</summary>
        /// <param name="handlerFactory">The <see cref="IEventHandlerFactory"/> object used to create new event handlers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handlerFactory"/> is <c>null</c>.</exception>
        public EventBroker(IEventHandlerFactory handlerFactory)
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
        /// <summary>Synchonously raises the specified event.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event to raise.</typeparam>
        /// <param name="domainEvent">The <see cref="IEvent"/> to raise.</param>
        public void Raise<T>(T domainEvent)
            where T : IEvent
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            var handlers = Factory.CreateHandlersFor<T>();

            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    try
                    {
                        handler.Handle(domainEvent);
                    }
                    finally
                    {
                        Factory.Release(handler);
                    }
                }
            }
        }

        /// <summary>Asynchronously raises the specified event.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event to raise.</typeparam>
        /// <param name="domainEvent">The <see cref="IEvent"/> to raise.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task RaiseAsync<T>(T domainEvent)
            where T : IEvent
        {
            await Task.Factory.StartNew(() => Raise(domainEvent));
        }
        #endregion
    }
}
