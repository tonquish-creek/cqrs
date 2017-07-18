using System.Diagnostics.CodeAnalysis;

namespace TonquishCreek.CQRS.Events
{
    /// <summary>Represents a notification that something has happened.</summary>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This is needed for proper routing and type enforcement. It is empty because there is nothing to put here.")]
    public interface IEventMessage
    {
    }
}
