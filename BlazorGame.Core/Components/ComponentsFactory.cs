using BlazorGame.Core.Exceptions;
using BlazorGame.Core.Interfaces;
using BlazorGame.Core.Models;
using System.Collections.Concurrent;
using System.Reflection;

namespace BlazorGame.Core.Components
{
    /// <summary>Factory class responsible of Component creation</summary>
    internal class ComponentsFactory
    {
        private readonly ConcurrentDictionary<Type, ConstructorInfo> _constructorsByType;

        private ComponentsFactory()
        {
            _constructorsByType = new ConcurrentDictionary<Type, ConstructorInfo>();
        }

        private static readonly Lazy<ComponentsFactory> _instance = new Lazy<ComponentsFactory>(new ComponentsFactory());

        /// <summary>Gets the instance.</summary>
        /// <value>The instance.</value>
        public static ComponentsFactory Instance => _instance.Value;

        /// <summary>Creates the specified object.</summary>
        /// <typeparam name="TC">The type of the c.</typeparam>
        /// <param name="owner">The object's owner.</param>
        /// <returns>
        ///  The created object.
        /// </returns>
        public TC Create<TC>(GameObject owner) where TC : class, IComponent
        {
            var ctor = GetConstructor<TC>();

            if (ctor == null)
            {
                throw new ComponentInitializationException<TC>();
            }

            return ctor.Invoke(new[] { owner }) as TC;
        }

        private ConstructorInfo GetConstructor<TC>() where TC : class, IComponent
        {
            var type = typeof(TC);

            if (!_constructorsByType.ContainsKey(type))
            {
                var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                    new[] { typeof(GameObject) }, null);

                if (ctor == null)
                {
                    throw new ComponentInitializationException<TC>();
                }

                _constructorsByType.AddOrUpdate(type, ctor, (t, c) => ctor);
            }

            return _constructorsByType[type];
        }
    }
}
