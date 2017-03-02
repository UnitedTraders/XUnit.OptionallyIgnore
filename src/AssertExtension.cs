namespace Xunit.SpecFlow.AssertSkip
{
    /// <summary>
    /// Additional Asserts for xUnit
    /// </summary>
    public static class AssertExtension
    {
        /// <summary>
        /// Skip method that works with Facts that have <see cref="OptionallyIgnoreTestFactAttribute"/> 
        /// </summary>
        /// <param name="reason">skip reason</param>
        public static void Skip(string reason)
        {
            throw new SkipException(reason);
        }
    }
}
