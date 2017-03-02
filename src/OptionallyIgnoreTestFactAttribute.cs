using System.Collections.Generic;
using Xunit.Sdk;

namespace Xunit.SpecFlow.AssertSkip
{
    public class OptionallyIgnoreTestFactAttribute : FactAttribute
    {
        protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
        {
            yield return new SkippableTestCommand(method);
        }

        class SkippableTestCommand : FactCommand
        {
            public SkippableTestCommand(IMethodInfo method) : base(method) { }

            public override MethodResult Execute(object testClass)
            {
                try
                {
                    return base.Execute(testClass);
                }
                catch (SkipException e)
                {
                    return new SkipResult(testMethod, DisplayName, e.Reason);
                }
            }
        }
    }
}
