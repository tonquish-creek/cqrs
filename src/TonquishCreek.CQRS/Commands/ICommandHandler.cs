using System;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary>Represents a command handler.</summary>
    /// <typeparam name="T">Indicates the <see cref="Type"/> of the command handled by the implementing class.</typeparam>
    public interface ICommandHandler<T> : IDisposable
        where T : ICommand
    {
        #region Method(s)
        /// <summary>Handles the specified command.</summary>
        /// <param name="command">The <see cref="ICommand"/> to handle.</param>
        void Handle(T command);
        #endregion
    }
}
