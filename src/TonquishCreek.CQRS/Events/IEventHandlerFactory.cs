using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TonquishCreek.CQRS.Events
{
    /// <summary></summary>
    public interface IEventHandlerFactory : IDisposable
    {
        #region Method(s)
        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This signature is required by some IoC frameworks to automatically implement the factory.")]
        IEnumerable<IEventHandler<T>> CreateHandlersFor<T>()
            where T : IEvent;

        /// <summary></summary>
        /// <param name="handler"></param>
        void Release<T>(IEventHandler<T> handler)
            where T : IEvent;
        #endregion
    }
}
