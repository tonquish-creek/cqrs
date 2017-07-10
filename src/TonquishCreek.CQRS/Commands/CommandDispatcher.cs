using System;
using System.Threading.Tasks;

namespace TonquishCreek.CQRS.Commands
{
    /// <summary></summary>
    public sealed class CommandDispatcher : ICommandDispatcher
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="CommandDispatcher"/> class.</summary>
        /// <param name="handlerFactory">The <see cref="ICommandHandlerFactory"/> object used to create new command handlers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handlerFactory"/> is <c>null</c>.</exception>
        public CommandDispatcher(ICommandHandlerFactory handlerFactory)
        {
            if (handlerFactory == null)
            {
                throw new ArgumentNullException(nameof(handlerFactory));
            }

            Factory = handlerFactory;
        }
        #endregion

        #region Public Properties
        /// <summary>Gets the <see cref="ICommandHandlerFactory"/> object used by the current instance to create new command handlers.</summary>
        /// <returns>The <see cref="ICommandHandlerFactory"/> used by the current instance.</returns>
        public ICommandHandlerFactory Factory { get; private set; }
        #endregion

        #region Public Method(s)
        /// <summary>Executes the specified command.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the command to execute.</typeparam>
        /// <param name="command">The <see cref="ICommand"/> to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is <c>null</c>.</exception>
        public void Execute<T>(T command)
            where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = CreateHandlerFor(command);

            try
            {
                handler.Handle(command);
            }
            finally
            {
                Factory.Release(handler);
            }
        }

        /// <summary>Asynchronously executes the specified command.</summary>
        /// <typeparam name="T">The <see cref="Type"/> of the command to execute.</typeparam>
        /// <param name="command">The <see cref="ICommand"/> to execute.</param>
        /// <returns>A <see cref="Task"/> object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is <c>null</c>.</exception>
        public async Task ExecuteAsync<T>(T command)
            where T : ICommand
        {
            await Task.Factory.StartNew(() => Execute(command));
        }
        #endregion

        #region Private Method(s)
        private ICommandHandler<T> CreateHandlerFor<T>(T command)
            where T : ICommand
        {
            var handler = Factory.CreateHandlerFor<T>();

            if (handler == null)
            {
                throw new OperationCanceledException("No handler found for " + command.GetType().FullName);
            }

            return handler;
        }
        #endregion
    }
}
