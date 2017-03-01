using System;

namespace XUnit.OptionallyIgnore.SpecFlowPlugin
{
    internal class SkipException : Exception
    {
        public SkipException(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; set; }
    }
}