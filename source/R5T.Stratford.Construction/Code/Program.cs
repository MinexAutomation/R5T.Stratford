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

            Console.WriteLine($"Assembly {assembly.FullName} - All types:");

            foreach (var type in assemblyTypes)
            {
                Console.WriteLine(type.Name);
            }

            // Get types inheriting (that can be assigned to) the service definition interface.
            var serviceDefinitionTypes = Utilities.FindIServiceDefinitionInterfaceTypes(assemblyTypes);

            Console.WriteLine();
            Console.WriteLine($"{typeof(IServiceDefinition).Name} types:");

            foreach (var serviceDefinitionType in serviceDefinitionTypes)
            {
                Console.WriteLine($"{serviceDefinitionType.Name}");
            }
            // Note: with the IsInterface check, all interfaces that inherit from an interface that inherits from the service definition interface will also inherit from the service definition interface.

            // Get types with the service definition attribute.
            var serviceDefinitionAttributedTypes = Utilities.FindServiceDefinitionAttributeTypes(assemblyTypes);

            Console.WriteLine();
            Console.WriteLine($"{typeof(ServiceDefinitionAttribute).Name} - Has attribute:");

            foreach (var serviceDefinitionAttributedType in serviceDefinitionAttributedTypes)
            {
                Console.WriteLine($"{serviceDefinitionAttributedType.Name}");
            }
            // Note: only the attributed interface is found, not classes implementing the interface, since the attribute only applies to interfaces.
        }
    }
}
