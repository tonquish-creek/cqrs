using System;
using SimpleInjector;
using SimpleInjector.Packaging;
using TonquishCreek.CQRS.Commands;

namespace TonquishCreek.CQRS.SimpleInjector
{
    /// <summary>Registers messaging types and services with the Simple Injector container.</summary>
    public sealed class SimpleInjectorModule : IPackage
    {
        #region Constructor(s)
        /// <summary>Initializes a new instance of the <see cref="SimpleInjectorModule"/> class.</summary>
        public SimpleInjectorModule()
        {
        }
        #endregion

        #region Public Method(s)
        /// <summary>Registers the set of services in the specified container.</summary>
        /// <param name="container">The container into which the set of services is registered.</param>
        /// <exception cref="ArgumentNullException"><paramref name="container"/> is <c>null</c>.</exception> 
        public void RegisterServices(Container container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container.RegisterSingleton<IMessageRouter, MessageRouter>();

            // Command Stuff
            container.RegisterSingleton<ICommandHandlerFactory, SimpleInjectorCommandMessageHandlerFactory>();
            container.RegisterSingleton<ICommandMessageRouter, CommandMessageRouter>();

            // Event Stuff
            //container.RegisterSingleton<IEventHandlerFactory, SimpleInjectorEventHandlerFactory>();
            //container.RegisterSingleton<IEventMessageRouter, EventMessageRouter>();

            // Query Stuff
            //container.RegisterSingleton<IQueryHandlerFactory, SimpleInjectorQueryHandlerFactory>();
            //container.RegisterSingleton<IQueryMessageRouter, QueryMessageRouter>();

            // Register handlers
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            container.Register(typeof(ICommandHandler<>), assemblies, Lifestyle.Scoped);
            //container.Register(typeof(IEventHandler<>), assemblies, Lifestyle.Scoped);
            //container.Register(typeof(IQueryHandler<,>), assemblies, Lifestyle.Scoped);
        }
        #endregion
    }
}
