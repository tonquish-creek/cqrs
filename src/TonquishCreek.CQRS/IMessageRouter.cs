using System.Threading;
using System.Threading.Tasks;
using TonquishCreek.CQRS.Commands;
using TonquishCreek.CQRS.Events;
using TonquishCreek.CQRS.Queries;

namespace TonquishCreek.CQRS
{
    /// <summary></summary>
    public interface IMessageRouter
    {
        #region Method(s)
        /// <summary>Raises the specified event asynchronously.</summary>
        /// <param name="message">The <see cref="IEventMessage"/> object to send.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        Task RaiseAsync(IEventMessage message);

        /// <summary>Sends the specified command asynchronously to the appropriate handler.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to send.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        Task SendAsync(ICommandMessage message);

        /// <summary>Sends the specified command asynchronously to the appropriate handler.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        Task SendAsync(ICommandMessage message, CancellationToken cancellationToken);

        /// <summary>Sends the specified query asynchronously to the appropriate handler and returns the result of the operation.</summary>
        /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) to return.</typeparam>
        /// <param name="message">The <see cref="IQueryMessage{TResult}"/> object to send.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing the data returned from the handler.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        Task<TResult> SendAsync<TResult>(IQueryMessage<TResult> message);

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
