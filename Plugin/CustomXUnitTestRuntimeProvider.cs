using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace McKeltCustom.Generator.SpecflowPlugin
{
    public class CustomXUnitTestRuntimeProvider : IUnitTestRuntimeProvider
    {
        public void TestPending(string message)
        {
            throw new SpecFlowException("Test pending: " + message);
        }

        public void TestInconclusive(string message)
        {
            throw new SpecFlowException("Test inconclusive: " + message);
        }

        public void TestIgnore(string message)
        {
            throw new SpecFlowException("Test ignored: " + message);
        }

        public bool DelayedFixtureTearDown
        {
            get { return false; }
        }
    }
}
