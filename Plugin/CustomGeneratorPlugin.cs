using BoDi;
using McKeltCustom.Generator.SpecflowPlugin;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: GeneratorPlugin(typeof(CustomGeneratorPlugin))]

namespace McKeltCustom.Generator.SpecflowPlugin
{

    public class CustomGeneratorPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {

        }

        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<CustomGeneratorProvider, IUnitTestGeneratorProvider>();
            container.RegisterTypeAs<CustomXUnitTestRuntimeProvider, IUnitTestRuntimeProvider>();
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {

        }
    }
}
