using System.Diagnostics.CodeAnalysis;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary>Represents an action that changes the state of the system.</summary>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This is needed for proper routing and type enforcement. It is empty because there is nothing to put here.")]
    public interface ICommandMessage
    {
    }
}
