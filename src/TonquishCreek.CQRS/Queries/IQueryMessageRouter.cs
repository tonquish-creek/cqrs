using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Queries
{
    public interface IQueryMessageRouter
    {
        #region Method(s)
        /// <summary>Sends the specified query asynchronously to the appropriate handler and returns the result of the operation.</summary>
        /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) to return.</typeparam>
        /// <param name="message">The <see cref="IQueryMessage{TResult}"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing the data returned from the handler.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        Task<TResult> SendAsync<TResult>(IQueryMessage<TResult> message, CancellationToken cancellationToken);
        #endregion
    }
}
