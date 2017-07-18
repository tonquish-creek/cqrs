using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Events
{
    /// <summary></summary>
    internal interface IEventMessageRouter
    {
        #region Method(s)
        /// <summary>Raises the specified event asynchronously.</summary>
        /// <param name="message">The <see cref="IEventMessage"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        Task RaiseAsync(IEventMessage message, CancellationToken cancellationToken);
        #endregion
    }
}
