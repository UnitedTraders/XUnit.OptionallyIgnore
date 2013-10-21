SpecFlowCustomPlugin
====================


XUnit Ignore test at runtime (with SpecFlow tag @IgnoreLocally)

As Xunit has no Assert.Ignore() using the OptionallyIgnoreTestFactAttribute attribute on a method and setting McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally == true will ignore the test at runtime

In SpecFlow set this as a plugin and use the tag @IgnoreLocally -- before each test scenario is run turn on/off the setting to run this test.


https://github.com/chrismckelt/SpecFlowCustomPlugin
 

Sample usage:


namespace Tester

{

    public class TestInitialise  // --- this is used by XUnits IUseTestFixture - on test startup

    {

        public TestInitialise()

        {

            McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally = true;

        }

    }

 

 

    public class TestFixture : IUseFixture<TestInitialise>

    {

        [OptionallyIgnoreTestFact]  // -------- SUB CLASSED FACT to determine whether to run the test or not

        public void DoesThisWork()

        {

            Assert.True(false, "This should not be run");

        }

 

        public void SetFixture(TestInitialise data)  // XUNIT requires this but do nothing with hit

        {


        }

    }

}

 
 --- SPECFLOW ONLY ---

SpecFlow tag can be on a feature or a scenario


Add the following to the .config file

 

&lt;specFlow&gt;
    &lt;!--&lt;unitTestProvider name=&quot;xUnit&quot; /&gt;--&gt;
    &lt;generator allowDebugGeneratedFiles=&quot;false&quot; allowRowTests=&quot;true&quot; generateAsyncTests=&quot;false&quot; path=&quot;.lib&quot;/&gt;
    &lt;runtime stopAtFirstError=&quot;false&quot; missingOrPendingStepsOutcome=&quot;Ignore&quot;&gt;
      &lt;!--&lt;dependencies&gt;
        &lt;register name=&quot;CustomGeneratorPlugin&quot; type=&quot;PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorPlugin, PhoenixCustom.Generator.SpecflowPlugin&quot; as=&quot;PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorPlugin, PhoenixCustom.Generator.SpecflowPlugin&quot; /&gt;
        &lt;register name=&quot;CustomGeneratorProvider&quot; type=&quot;PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorProvider, PhoenixCustom.Generator.SpecflowPlugin&quot; as=&quot;PhoenixCustom.Generator.SpecflowPlugin.CustomGeneratorProvider, PhoenixCustom.Generator.SpecflowPlugin&quot; /&gt;
      &lt;/dependencies&gt;--&gt;
    &lt;/runtime&gt;
    &lt;trace traceSuccessfulSteps=&quot;true&quot; traceTimings=&quot;false&quot; minTracedDuration=&quot;0:0:0.1&quot; stepDefinitionSkeletonStyle=&quot;RegexAttribute&quot;/&gt;
    &lt;plugins&gt;
      &lt;add name=&quot;McKeltCustom&quot; path=&quot;.lib&quot; type=&quot;GeneratorAndRuntime&quot;/&gt;
    &lt;/plugins&gt;
    &lt;!-- For additional details on SpecFlow configuration options see http://go.specflow.org/doc-config --&gt;
    &lt;stepAssemblies&gt;
      &lt;!-- This attribute is required in order to use StepArgument Transformation as described here; 
    https://github.com/marcushammarberg/SpecFlow.Assist.Dynamic/wiki/Step-argument-transformations  --&gt;
      &lt;!-- This attribute is required in order to use StepArgument Transformation as described here; 
    https://github.com/marcusoftnet/SpecFlow.Assist.Dynamic/wiki/Step-argument-transformations  --&gt;
      &lt;stepAssembly assembly=&quot;SpecFlow.Assist.Dynamic&quot;/&gt;
    &lt;/stepAssemblies&gt;
  &lt;/specFlow&gt;


 

Finally put the all compiled assemblies into a lib folder in the root folder of your SpecFlow project

 
 

Tests marked with @IgnoreLocally  or OptionallyIgnoreTest will now skip the test if McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally = true

 
http://www.mckelt.com/post/2013/10/06/XUnit-Ignore-test-at-runtime-%28with-SpecFlow-tag-IgnoreLocally%29.aspx


