using System;

namespace TonquishCreek.CQRS.Events
{
    /// <summary>Abstract base class for all event handlers.</summary>
    /// <typeparam name="TEvent">Indicates the <see cref="Type"/> of the event handled by the handler.</typeparam>
    public abstract class EventHandlerBase<TEvent> : HandlerBase, IEventHandler<TEvent>
        where TEvent : class, IEventMessage
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="EventHandlerBase{TEvent}" /> class.</summary>
        protected EventHandlerBase()
            : base()
        {
        }
        #endregion

        #region Public Method(s)
        /// <summary>Handles the specified event.</summary>
        /// <param name="domainEvent">The <see cref="IEventMessage" /> to handle.</param>
        public void Handle(TEvent domainEvent)
        {
            ThrowIfDisposed();

            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            HandleEvent(domainEvent);
        }
        #endregion

        #region Protected Method(s)
        // This is stupid!!!
        //protected override void Dispose(Boolean disposing)
        //{
        //    base.Dispose(disposing);
        //}

        /// <summary>Overridden byHandles the specified event.</summary>
        /// <param name="domainEvent">The <see cref="IEventMessage" /> to handle.</param>
        protected abstract void HandleEvent(TEvent domainEvent);
        #endregion
    }
}
