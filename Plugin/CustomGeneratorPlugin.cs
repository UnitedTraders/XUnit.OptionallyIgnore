using BoDi;
using McKeltCustom.SpecflowPlugin;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;


namespace McKeltCustom.SpecflowPlugin
{

    public class CustomGeneratorPlugin : IGeneratorPlugin, IRuntimePlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {

        }

        public void RegisterCustomizations(ObjectContainer container, RuntimeConfiguration runtimeConfiguration)
        {
            container.RegisterTypeAs<CustomGeneratorProvider, IUnitTestGeneratorProvider>();
            container.RegisterTypeAs<CustomXUnitTestRuntimeProvider, IUnitTestRuntimeProvider>();


        }

        public void RegisterConfigurationDefaults(RuntimeConfiguration runtimeConfiguration)
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
