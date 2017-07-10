namespace TonquishCreek.CQRS.Queries
{
    public interface IQueryProcessor
    {
        #region Method(s)
        /// <summary>Executes the specified query.</summary>
        /// <typeparam name="TQuery">The <see cref="Type"/> of the query to execute.</typeparam>
        /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) to return.</typeparam>
        /// <param name="query">The <see cref="IQuery{TResult}"/> to execute.</param>
        /// <returns>The result(s) of the query.</returns>
        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>;
        #endregion
    }
}
