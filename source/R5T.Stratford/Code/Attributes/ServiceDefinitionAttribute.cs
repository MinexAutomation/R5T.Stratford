using System;


namespace R5T.Stratford
{
    /// <summary>
    /// Attribute indicating that the attributed interface is a service definition.
    /// Inherited is false, since classes *implement* an interface, not inherit from it, and inherited interfaces also do not seem to work.
    /// Note that class which implement the attributed interface LOSE the attribute since it ONLY applies to interfaces.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceDefinitionAttribute : Attribute
    {
        public ServiceDefinitionAttribute()
        {
        }
    }
}
