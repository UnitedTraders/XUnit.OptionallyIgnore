namespace XUnit.OptionallyIgnore.SpecFlowPlugin
{
    public static class AssertExtension
    {
        public static void Skip(string reason)
        {
            throw new SkipException(reason);
        }
    }
}
