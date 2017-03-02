using System;

namespace Xunit.SpecFlow.AssertSkip
{
    internal class SkipException : Exception
    {
        public SkipException(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; }
    }
}