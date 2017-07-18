using System;
using System.Threading;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Queries
{
    /// <summary>Represents a query handler.</summary>
    /// <typeparam name="TMessage">The <see cref="Type"/> of the query handled by the implementing class.</typeparam>
    /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) returned by the handler.</typeparam>
    public interface IQueryHandler<TMessage, TResult> : IDisposable
        where TMessage : IQueryMessage<TResult>
    {
        #region Method(s)
        /// <summary>Handles the specified event message.</summary>
        /// <param name="message">The <see cref="IQueryMessage{TResult}"/> to handle.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandleAsync(TMessage message, CancellationToken cancellationToken);
        #endregion
    }
}
