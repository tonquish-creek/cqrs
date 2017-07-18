using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary></summary>
    internal interface ICommandMessageRouter
    {
        #region Method(s)
        /// <summary>Sends the specified command asynchronously to the appropriate handler.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SendAsync(ICommandMessage message, CancellationToken cancellationToken);
        #endregion
    }
}
