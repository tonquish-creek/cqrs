using System;
using System.Diagnostics.CodeAnalysis;
using TonquishCreek.CQRS.Events;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary>Abstract base class for all command handlers.</summary>
    /// <typeparam name="TCommand">Indicates the <see cref="Type"/> of the command handled by the handler.</typeparam>
    public abstract class CommandHandlerBase<TCommand> : HandlerBase, ICommandHandler<TCommand>
        where TCommand : class, ICommand
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="CommandHandlerBase{TCommand}"/> class.</summary>
        /// <param name="eventBroker">The <see cref="IEventBroker"/> object used by the new instance to raise domain events.</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventBroker"/>  is <c>null</c>.</exception>
        protected CommandHandlerBase(IEventBroker eventBroker) // TODO: Is there another way to inject this without cluttering the constructor?
        {
            if (eventBroker == null)
            {
                throw new ArgumentNullException(nameof(eventBroker));
            }

            EventBroker = eventBroker;
        }
        #endregion

        #region Public Properties
        /// <summary>Gets the event broker used by the current instance to raise domain events.</summary>
        /// <returns>An <see cref="IEventBroker"/> object representing the event broker.</returns>
        public IEventBroker EventBroker { get; private set; }
        #endregion

        #region Public Method(s)
        /// <summary>When overridden in a derived class, handles the specified command.</summary>
        /// <param name="command">The <see cref="ICommand" /> to handle.</param>
        public abstract void Handle(TCommand command);
        #endregion

        #region Protected Method(s)
        /// <summary>Raises the specified event.</summary>
        /// <typeparam name="TEvent">The <see cref="Type"/> of the event to raise.</typeparam>
        /// <param name="e">The <see cref="IEvent"/> to raise.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Justification = "Generic name.")]
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "By Design.")]
        protected void Raise<TEvent>(TEvent e)
            where TEvent : IEvent
        {
            EventBroker.Raise(e);
        }

        /// <summary>Raises the specified event.</summary>
        /// <typeparam name="TEvent">The <see cref="Type"/> of the event to raise.</typeparam>
        /// <param name="e">The <see cref="IEvent"/> to raise.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Justification = "Generic name.")]
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "By Design.")]
        protected void RaiseAsync<TEvent>(TEvent e)
            where TEvent : IEvent
        {
            EventBroker.RaiseAsync(e);
        }
        #endregion
    }
}
