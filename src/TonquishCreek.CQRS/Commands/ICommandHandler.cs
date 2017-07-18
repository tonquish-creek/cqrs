using System;
using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary>Represents a command handler.</summary>
    /// <typeparam name="TMessage">Indicates the <see cref="Type"/> of the command handled by the implementing class.</typeparam>
    public interface ICommandHandler<TMessage> : IDisposable
        where TMessage : ICommandMessage
    {
        #region Method(s)
        /// <summary>Handles the specified command message.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> to handle.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandleAsync(TMessage message, CancellationToken cancellationToken);
        #endregion
    }
}
