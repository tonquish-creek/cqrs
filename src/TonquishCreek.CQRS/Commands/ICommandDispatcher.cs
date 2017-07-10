using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary></summary>
    public interface ICommandDispatcher
    {
        #region Method(s)
        /// <summary>Executes the specified command.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the command to execute.</typeparam>
        /// <param name="command">The <see cref="ICommand"/> to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is <c>null</c>.</exception>
        void Execute<T>(T command)
            where T : ICommand;

        /// <summary>Asynchronously executes the specified command.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the command to execute.</typeparam>
        /// <param name="command">The <see cref="ICommand"/> to execute.</param>
        /// <returns>A <see cref="Task"/> object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is <c>null</c>.</exception>
        Task ExecuteAsync<T>(T command)
            where T : ICommand;
        #endregion
    }
}
