namespace TonquishCreek.CQRS.Queries
{
    /// <summary>Abstract base class for query handlers.</summary>
    public abstract class QueryHandlerBase<TQuery, TResult> : HandlerBase, IQueryHandler<TQuery, TResult>
        where TQuery : class, IQueryMessage<TResult>
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="QueryHandlerBase{TQuery, TResult}" /> class.</summary>
        protected QueryHandlerBase()
            : base()
        {
        }
        #endregion

        #region Public Method(s)
        /// <summary>Handles the specified query.</summary>
        /// <param name="query">The query to handle.</param>
        /// <returns>An object representing the query results.</returns>
        public abstract TResult Handle(TQuery query);
        #endregion

        #region IQueryHandler Member(s)
        TResult IQueryHandler<TResult>.Handle(IQueryMessage<TResult> query)
        {
            return Handle(query as TQuery);
        }
        #endregion
    }
}
