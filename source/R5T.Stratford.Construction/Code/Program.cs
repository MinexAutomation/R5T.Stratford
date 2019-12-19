using System;
using System.Linq;
using System.Reflection;


namespace R5T.Stratford.Construction
{
    class Program
    {
        static void Main()
        {
            Program.TestReflection();
        }

        private static void TestReflection()
        {
            var assembly = Assembly.GetAssembly(typeof(Program));

            // Get all assembly types.
            var assemblyTypes = assembly.GetTypes();

            foreach (var type in assemblyTypes)
            {
                Console.WriteLine(type.Name);
            }

            // Get types inheriting (that can be assigned to) the service definition interface.
            var serviceDefinitionInterfaceType = typeof(IServiceDefinition);

            var serviceDefinitionTypes = assemblyTypes.Where(type => type.IsInterface && serviceDefinitionInterfaceType.IsAssignableFrom(type));

            foreach (var serviceDefinitionType in serviceDefinitionTypes)
            {
                Console.WriteLine($"{serviceDefinitionType.Name}: {serviceDefinitionInterfaceType.Name}");
            }
            // Note: with the IsInterface check, all interfaces that inherit from an interface that inherits from the service definition interface will also inherit from the service definition interface.

            // Get types with the service definition attribute.
            var serviceDefinitionAttribute = typeof(ServiceDefinitionAttribute);

            var serviceDefinitionAttributedTypes = assemblyTypes.Where(type =>
            {
                var customAttributes = type.GetCustomAttributes(serviceDefinitionAttribute, true); // Make sure to include inheritance tree.

                var hasAttribute = customAttributes.Count() > 0;
                return hasAttribute;
            });

            foreach (var serviceDefinitionAttributedType in serviceDefinitionAttributedTypes)
            {
                Console.WriteLine($"{serviceDefinitionAttributedType.Name}: has attribute {serviceDefinitionAttribute.Name}");
            }
            // Note: only the attributed interface is found, not classes implementing the interface, since the attribute only applies to interfaces.
        }
    }
}
