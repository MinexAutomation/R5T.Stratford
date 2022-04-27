using System;using R5T.T0064;


namespace R5T.Stratford.Construction
{[ServiceDefinitionMarker]
    // Does not have ServiceDefinition attribute.
    public interface IServiceDefinitionAttributedTest2 : IServiceDefinitionAttributedTest,IServiceDefinition
    {
    }
}
