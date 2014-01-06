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
