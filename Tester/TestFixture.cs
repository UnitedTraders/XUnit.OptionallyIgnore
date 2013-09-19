using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKeltCustom.SpecflowPlugin;
using Xunit;

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
