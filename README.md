SpecFlowCustomPlugin
====================

XUnit Ignore test at runtime (with SpecFlow tag @IgnoreLocally)

As Xunit has no Assert.Ignore() using the OptionallyIgnoreTestFactAttribute attribute on a method and setting McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally == true will ignore the test at runtime

In SpecFlow set this as a plugin and use the tag @IgnoreLocally -- before each test scenario is run turn on/off the setting to run this test.

Sample usage:

namespace Tester
{

    public  class Dummy
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
        }
    }
}




