namespace Xunit.SpecFlow.AssertSkip.Tester
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
