using System.Diagnostics.CodeAnalysis;

namespace TonquishCreek.CQRS.Queries
{
    /// <summary>Represents an action that returns data.</summary>
    /// <typeparam name="TResult"></typeparam>
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This is needed for proper routing and type enforcement. It is empty because there is nothing to put here.")]
    public interface IQuery<TResult>
    {
    }
}
