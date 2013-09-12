using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McKeltCustom.SpecflowPlugin;
using Xunit;

namespace Tester
{
    public class TestFixture
    {
        [OptionallyIgnoreTestFact]
        public void DoesThisWork()
        {
            Assert.True(true);
        }
    }
}
