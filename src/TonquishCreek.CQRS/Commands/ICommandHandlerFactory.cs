using System;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary></summary>
    public interface ICommandHandlerFactory : IDisposable
    {
        #region Method(s)
        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommandHandler<T> CreateHandlerFor<T>()
            where T : ICommand;

        /// <summary></summary>
        /// <param name="handler"></param>
        void Release<T>(ICommandHandler<T> handler)
            where T : ICommand;
        #endregion
    }
}
