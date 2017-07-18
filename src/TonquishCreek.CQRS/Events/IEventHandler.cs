using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Events
{
    /// <summary>Represents an event handler.</summary>
    /// <typeparam name="TMessage">Indicates the <see cref="Type"/> of the event handled by the implementing class.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Code Analysis doesn't like the 'EventHandler' suffix.")]
    public interface IEventHandler<TMessage> : IDisposable
        where TMessage : IEventMessage
    {
        #region Method(s)
        /// <summary>Handles the specified event message.</summary>
        /// <param name="message">The <see cref="IEventMessage"/> to handle.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandleAsync(TMessage message, CancellationToken cancellationToken);
        #endregion
    }
}
