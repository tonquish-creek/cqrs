using System;
using SimpleInjector;
using TonquishCreek.CQRS.Commands;

namespace TonquishCreek.CQRS.SimpleInjector
{
    internal sealed class SimpleInjectorCommandMessageHandlerFactory : ICommandHandlerFactory
    {
        #region Private Field(s)
        private Container _container;
        #endregion

        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="SimpleInjectorCommandMessageHandlerFactory"/> class using the specified container.</summary>
        /// <param name="container">The <see cref="Container"/> used by the new instance to retrieve handler instances.</param>
        /// <exception cref="ArgumentNullException"><paramref name="container"/> is <c>null</c>.</exception> 
        public SimpleInjectorCommandMessageHandlerFactory(Container container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            _container = container;
        }
        #endregion

        #region Public Method(s)
        public ICommandHandler<TMessage> CreateHandlerFor<TMessage>(TMessage message)
            where TMessage : ICommandMessage
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(message.GetType());

            return _container.GetInstance(handlerType) as ICommandHandler<TMessage>;
        }

        public void Release<TMessage>(ICommandHandler<TMessage> handler)
            where TMessage : ICommandMessage
        {
            // Do nothing
        }
        #endregion
    }
}
