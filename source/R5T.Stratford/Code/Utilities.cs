using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace R5T.Stratford
{
    public static class Utilities
    {
        /// <summary>
        /// Finds types that are interfaces and are assignable to <see cref="IServiceDefinition"/>.
        /// </summary>
        public static IEnumerable<Type> FindIServiceDefinitionInterfaceTypes(IEnumerable<Type> types)
        {
            var serviceDefinitionInterfaceType = typeof(IServiceDefinition);

            var serviceDefinitionTypes = types.Where(type => type.IsInterface && serviceDefinitionInterfaceType.IsAssignableFrom(type));
            return serviceDefinitionTypes;
        }

        public static IEnumerable<Type> FindIServiceDefinitionInterfaceTypes(Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();

            var serviceDefinitionTypes = Utilities.FindIServiceDefinitionInterfaceTypes(assemblyTypes);
            return serviceDefinitionTypes;
        }

        public static IEnumerable<Type> FindServiceDefinitionAttributeTypes(IEnumerable<Type> types)
        {
            var serviceDefinitionAttribute = typeof(ServiceDefinitionAttribute);

            var serviceDefinitionAttributedTypes = types.Where(type =>
            {
                var customAttributes = type.GetCustomAttributes(serviceDefinitionAttribute, true); // Make sure to include inheritance tree.

                var hasAttribute = customAttributes.Count() > 0;
                return hasAttribute;
            });

            return serviceDefinitionAttributedTypes;
        }

        public static IEnumerable<Type> FindServiceDefinitionAttributeTypes(Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();

            var serviceDefinitionTypes = Utilities.FindServiceDefinitionAttributeTypes(assemblyTypes);
            return serviceDefinitionTypes;
        }
    }
}
