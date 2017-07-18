using System;

namespace TonquishCreek.CQRS.Queries
{
    /// <summary></summary>
    public sealed class QueryProcessor : IQueryMessageRouter
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="QueryProcessor"/> class.</summary>
        /// <param name="handlerFactory">The <see cref="IQueryHandlerFactory"/> object used to create new query handlers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handlerFactory"/>.</exception>
        public QueryProcessor(IQueryHandlerFactory handlerFactory)
        {
            if (handlerFactory == null)
            {
                throw new ArgumentNullException(nameof(handlerFactory));
            }

            Factory = handlerFactory;
        }
        #endregion

        #region Public Properties
        /// <summary>Gets the <see cref="IQueryHandlerFactory"/> object used by the current instance to create new command handlers.</summary>
        /// <returns>The <see cref="IQueryHandlerFactory"/> used by the current instance.</returns>
        public IQueryHandlerFactory Factory { get; private set; }
        #endregion

        #region Public Method(s)
        /// <summary>Executes the specified query.</summary>
        /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) to return.</typeparam>
        /// <param name="query">The <see cref="IQueryMessage{TResult}"/> to execute.</param>
        /// <returns>An object representing the query results.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="query"/> is <c>null</c>.</exception>
        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQueryMessage<TResult>
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = CreateHandlerFor(query);

            try
            {
                var result = handler.Handle(query);

                return result;
            }
            finally
            {
                Factory.Release(handler);
            }
        }
        #endregion

        #region Private Method(s)
        private IQueryHandler<TResult> CreateHandlerFor<TResult>(IQueryMessage<TResult> query)
        {
            var handler = Factory.CreateHandlerFor(query);

            if (handler == null)
            {
                throw new OperationCanceledException("No handler found for " + query.GetType().FullName);
            }

            return handler;
        }
        #endregion
    }
}
