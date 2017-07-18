using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary>Abstract base class for all command handlers.</summary>
    /// <typeparam name="TMessage">Indicates the <see cref="Type"/> of the command handled by the handler.</typeparam>
    public abstract class CommandHandlerBase<TMessage> : HandlerBase, ICommandHandler<TMessage>
        where TMessage : class, ICommandMessage
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="CommandHandlerBase{TMessage}"/> class.</summary>
        protected CommandHandlerBase()
            : base()
        {
        }
        ///// <summary>Initializes a new instance of the <see cref="CommandMessageHandlerBase{TMessage}"/> class.</summary>
        ///// <param name="eventBroker">The <see cref="IEventMessageRouter"/> object used by the new instance to raise domain events.</param>
        ///// <exception cref="ArgumentNullException"><paramref name="eventBroker"/>  is <c>null</c>.</exception>
        //protected CommandMessageHandlerBase(IEventMessageRouter eventBroker) // TODO: Is there another way to inject this without cluttering the constructor?
        //{
        //    if (eventBroker == null)
        //    {
        //        throw new ArgumentNullException(nameof(eventBroker));
        //    }

        //    EventBroker = eventBroker;
        //}
        #endregion

        #region Public Properties
        ///// <summary>Gets the event broker used by the current instance to raise domain events.</summary>
        ///// <returns>An <see cref="IEventMessageRouter"/> object representing the event broker.</returns>
        //public IEventMessageRouter EventBroker { get; private set; }
        #endregion

        #region Public Method(s)
        /// <summary>Handles the specified command message.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> to handle.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public abstract Task HandleAsync(TMessage message, CancellationToken cancellationToken);
        #endregion

        #region Protected Method(s)
        ///// <summary>Raises the specified event.</summary>
        ///// <typeparam name="TEvent">The <see cref="Type"/> of the event to raise.</typeparam>
        ///// <param name="e">The <see cref="IEventMessage"/> to raise.</param>
        //[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Justification = "Generic name.")]
        //[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "By Design.")]
        //protected void Raise<TEvent>(TEvent e)
        //    where TEvent : IEventMessage
        //{
        //    EventBroker.Raise(e);
        //}

        ///// <summary>Raises the specified event.</summary>
        ///// <typeparam name="TEvent">The <see cref="Type"/> of the event to raise.</typeparam>
        ///// <param name="e">The <see cref="IEventMessage"/> to raise.</param>
        //[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Justification = "Generic name.")]
        //[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "By Design.")]
        //protected void RaiseAsync<TEvent>(TEvent e)
        //    where TEvent : IEventMessage
        //{
        //    EventBroker.RaiseAsync(e);
        //}
        #endregion
    }
}
