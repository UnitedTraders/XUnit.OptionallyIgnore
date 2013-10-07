SpecFlowCustomPlugin
====================


XUnit Ignore test at runtime (with SpecFlow tag @IgnoreLocally)

As Xunit has no Assert.Ignore() using the OptionallyIgnoreTestFactAttribute attribute on a method and setting McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally == true will ignore the test at runtime

In SpecFlow set this as a plugin and use the tag @IgnoreLocally -- before each test scenario is run turn on/off the setting to run this test.


https://github.com/chrismckelt/SpecFlowCustomPlugin
 

Sample usage:

 

namespace Tester

{

    public class Dummy

    {

        public Dummy()

        {

            McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally = true;

        }

    }

 

 

    public class TestFixture : IUseFixture<Dummy>

    {

        [OptionallyIgnoreTestFact]

        public void DoesThisWork()

        {

            Assert.True(false, "This should not be run");

        }

 

        public void SetFixture(Dummy data)

        {

            throw new NotImplementedException();

        }

    }

}

 

SpecFlow tag can be on a feature or a scenario


Add the following to the .config file

 

<specFlow>
    <!--<unitTestProvider name="xUnit" />-->
    <generator allowDebugGeneratedFiles="false" allowRowTests="true" generateAsyncTests="false" path=".\lib"/>
    <runtime stopAtFirstError="false" missingOrPendingStepsOutcome="Ignore">
      <!--<dependencies>
        <register name="CustomGeneratorPlugin" type="PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorPlugin, PhoenixCustom.Generator.SpecflowPlugin" as="PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorPlugin, PhoenixCustom.Generator.SpecflowPlugin" />
        <register name="CustomGeneratorProvider" type="PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorProvider, PhoenixCustom.Generator.SpecflowPlugin" as="PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorProvider, PhoenixCustom.Generator.SpecflowPlugin" />
      </dependencies>-->
    </runtime>
    <trace traceSuccessfulSteps="true" traceTimings="false" minTracedDuration="0:0:0.1" stepDefinitionSkeletonStyle="RegexAttribute"/>
    <plugins>
      <add name="McKeltCustom" path=".\lib" type="GeneratorAndRuntime"/>
    </plugins>
    <!-- For additional details on SpecFlow configuration options see http://go.specflow.org/doc-config -->
    <stepAssemblies>
      <!-- This attribute is required in order to use StepArgument Transformation as described here; 
    https://github.com/marcushammarberg/SpecFlow.Assist.Dynamic/wiki/Step-argument-transformations  -->
      <!-- This attribute is required in order to use StepArgument Transformation as described here; 
    https://github.com/marcusoftnet/SpecFlow.Assist.Dynamic/wiki/Step-argument-transformations  -->
      <stepAssembly assembly="SpecFlow.Assist.Dynamic"/>
    </stepAssemblies>
  </specFlow>

 

Finally put the all compiled assemblies into a lib folder in the root folder of your SpecFlow project

 
 

Tests marked with @IgnoreLocally  or OptionallyIgnoreTest will now skip the test if McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally = true

 
http://www.mckelt.com/post/2013/10/06/XUnit-Ignore-test-at-runtime-%28with-SpecFlow-tag-IgnoreLocally%29.aspx


