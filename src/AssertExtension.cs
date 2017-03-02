namespace Xunit.SpecFlow.AssertSkip
{
    public static class AssertExtension
    {
        public static void Skip(string reason)
        {
            throw new SkipException(reason);
        }
    }
}
