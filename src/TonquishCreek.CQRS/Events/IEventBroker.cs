using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Events
{
    /// <summary></summary>
    public interface IEventBroker
    {
        #region Method(s)

        /// <summary>Synchronously raises the specified event.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event to raise.</typeparam>
        /// <param name="domainEvent">The <see cref="IEvent"/> to raise.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Code Analysis sees 'Raise' and thinks this is a traditional event.")]
        void Raise<T>(T domainEvent)
            where T : IEvent;

        /// <summary>Asynchronously raises the specified event.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the event to raise.</typeparam>
        /// <param name="domainEvent">The <see cref="IEvent"/> to raise.</param>
        /// <returns>A <see cref="T:Task"/> representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Code Analysis sees 'Raise' and thinks this is a traditional event.")]
        Task RaiseAsync<T>(T domainEvent)
            where T : IEvent;
        #endregion
    }
}
