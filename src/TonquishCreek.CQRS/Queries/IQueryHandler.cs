using System;

namespace TonquishCreek.CQRS.Queries
{
    /// <summary>Represents a query handler.</summary>
    /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) returned by the handler.</typeparam>
    public interface IQueryHandler<TResult> : IDisposable
    {
        #region Method(s)
        /// <summary>Handles the specified query.</summary>
        /// <param name="query">The <see cref="IQuery{TResult}"/> to handle.</param>
        /// <returns>An object representing the query results.</returns>
        TResult Handle(IQuery<TResult> query);
        #endregion
    }

    /// <summary>Represents a query handler.</summary>
    /// <typeparam name="TQuery">The <see cref="Type"/> of the query handled by the implementing class.</typeparam>
    /// <typeparam name="TResult">The <see cref="Type"/> of the result(s) returned by the handler.</typeparam>
    public interface IQueryHandler<TQuery, TResult> : IQueryHandler<TResult>, IDisposable
        where TQuery : IQuery<TResult>
    {
    }
}
