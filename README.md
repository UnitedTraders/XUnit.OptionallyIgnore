XUnit Ignore test at runtime
XUnit - [OptionallyIgnoreTestFact]

SpecFlow tag @OptionallyIgnore


As Xunit has no Assert.Ignore() using the above attribute/tag and setting the following flag will ignore tests at runtime

 

XUnit.OptionallyIgnore.SpecFlowPlugin.Settings.IgnoreLocally == true

 

https://github.com/chrismckelt/XUnit.OptionallyIgnore

 

Use Cases include: long running tests that should only run on the build.

 

Sample usage:

 

using System;
using Xunit;
using XUnit.OptionallyIgnore.SpecFlowPlugin;

namespace XUnit.OptionallyIgnore.Tester
{
    public class Dummy
    {
        public Dummy()
        {
            Settings.OptionallyIgnore = true;
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
 

