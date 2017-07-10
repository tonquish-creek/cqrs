using System;
using System.Diagnostics.CodeAnalysis;

namespace TonquishCreek.CQRS.Events
{
    /// <summary>Represents an event handler.</summary>
    /// <typeparam name="T">Indicates the <see cref="Type"/> of the event handled by the implementing class.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Code Analysis doesn't like the 'EventHandler' suffix.")]
    public interface IEventHandler<T> : IDisposable
        where T : IEvent
    {
        #region Method(s)
        /// <summary>Handles the specified event.</summary>
        /// <param name="domainEvent">The <see cref="IEvent"/> to handle.</param>
        void Handle(T domainEvent);
        #endregion
    }
}
