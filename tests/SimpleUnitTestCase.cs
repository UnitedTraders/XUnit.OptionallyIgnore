using XUnit.OptionallyIgnore.SpecFlowPlugin;

namespace XUnit.OptionallyIgnore.Tester
{
    public class SampleIgnoreTest
    {
        [OptionallyIgnoreTestFact]
        public void SampleTest()
        {
            AssertExtension.Skip("Some ignore reason");
        }
    }
}
