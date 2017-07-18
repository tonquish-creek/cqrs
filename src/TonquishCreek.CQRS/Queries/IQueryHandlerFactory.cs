using System;

namespace TonquishCreek.CQRS.Queries
{
    /// <summary></summary>
    public interface IQueryHandlerFactory : IDisposable
    {
        #region Method(s)
        /// <summary></summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        IQueryHandler<TResult> CreateHandlerFor<TResult>(IQueryMessage<TResult> query);

        /// <summary></summary>
        /// <param name="handler"></param>
        void Release<TResult>(IQueryHandler<TResult> handler);
        #endregion
    }
}
