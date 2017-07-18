using System;
using System.Threading;
using System.Threading.Tasks;
using TonquishCreek.CQRS.Commands;
using TonquishCreek.CQRS.Events;
using TonquishCreek.CQRS.Queries;

namespace TonquishCreek.CQRS
{
    // TODO: Consider if there is any benefit to implementing IDisposable

    internal sealed class MessageRouter : IMessageRouter
    {
        #region Private Field(s)
        private readonly ICommandMessageRouter _commandRouter;
        private readonly IEventMessageRouter _eventRouter;
        private readonly IQueryMessageRouter _queryRouter;
        #endregion

        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="MessageRouter"/> class.</summary>
        /// <param name="commandRouter">The <see cref="ICommandMessageRouter"/> object used by the new instance to route command messages.</param>
        /// <param name="eventRouter">The <see cref="IEventMessageRouter"/> object used by the new instance to route command messages.</param>
        /// <param name="queryRouter">The <see cref="IQueryMessageRouter"/> object used by the new instance to route command messages.</param>
        /// <exception cref="ArgumentNullException">One or more of the parameters is <c>null</c>.</exception> 
        public MessageRouter(ICommandMessageRouter commandRouter, IEventMessageRouter eventRouter, IQueryMessageRouter queryRouter)
        {
            if (commandRouter == null)
            {
                throw new ArgumentNullException(nameof(commandRouter));
            }

            if (eventRouter == null)
            {
                throw new ArgumentNullException(nameof(eventRouter));
            }

            if (queryRouter == null)
            {
                throw new ArgumentNullException(nameof(queryRouter));
            }

            _commandRouter = commandRouter;
            _eventRouter = eventRouter;
            _queryRouter = queryRouter;
        }
        #endregion

        #region Public Method(s)
        /// <summary>Raises the specified event asynchronously.</summary>
        /// <param name="message">The <see cref="IEventMessage"/> object to send.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        public Task RaiseAsync(IEventMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return _eventRouter.RaiseAsync(message);
        }

        /// <summary>Sends the specified command asynchronously to the appropriate handler.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to send.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        public Task SendAsync(ICommandMessage message)
        {
            return SendAsync(message, CancellationToken.None);
        }

        /// <summary>Sends the specified command asynchronously to the appropriate handler.</summary>
        /// <param name="message">The <see cref="ICommandMessage"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        public Task SendAsync(ICommandMessage message, CancellationToken cancellationToken)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return _commandRouter.SendAsync(message, cancellationToken);
        }

        /// <summary>Sends the specified query asynchronously to the appropriate handler and returns the result of the operation.</summary>
        /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) to return.</typeparam>
        /// <param name="message">The <see cref="IQueryMessage{TResult}"/> object to send.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing the data returned from the handler.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        public Task<TResult> SendAsync<TResult>(IQueryMessage<TResult> message)
        {
            return SendAsync(message, CancellationToken.None);
        }

        /// <summary>Sends the specified query asynchronously to the appropriate handler and returns the result of the operation.</summary>
        /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) to return.</typeparam>
        /// <param name="message">The <see cref="IQueryMessage{TResult}"/> object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation containing the data returned from the handler.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception> 
        public Task<TResult> SendAsync<TResult>(IQueryMessage<TResult> message, CancellationToken cancellationToken)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return _queryRouter.SendAsync(message, cancellationToken);
        }
        #endregion
    }
}
