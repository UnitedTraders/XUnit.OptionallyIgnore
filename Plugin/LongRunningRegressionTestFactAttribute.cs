using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Sdk;

namespace McKeltCustom.Generator.SpecflowPlugin
{
    public class LongRunningRegressionTestFactAttribute : FactAttribute
    {
        public const string LongRunningTest = "LongRunningTest";
        public const string OnlyRunOnBuildServer = "OnlyRunOnBuildServer";
        public const string LongRunningRegressionTest = "LongRunningRegressionTest";
        public const string IgnoreLocally = "IgnoreLocally";

        protected override IEnumerable<Xunit.Sdk.ITestCommand> EnumerateTestCommands(Xunit.Sdk.IMethodInfo method)
        {
            bool ignore = ScenarioContext.Current.ScenarioInfo.Tags.Contains(LongRunningTest) ||
                          ScenarioContext.Current.ScenarioInfo.Tags.Contains(OnlyRunOnBuildServer) ||
                          ScenarioContext.Current.ScenarioInfo.Tags.Contains(LongRunningRegressionTest) ||
                          ScenarioContext.Current.ScenarioInfo.Tags.Contains(IgnoreLocally);

            if (ignore)
            {
                string msg = ScenarioContext.Current.ScenarioInfo.Tags.Aggregate(string.Empty, (current, tag) => current + (tag + " : "));

                yield return new SkipCommand(method, ScenarioContext.Current.ScenarioInfo.Title, "Test Ignored: " + msg);
            }

            var cmds = base.EnumerateTestCommands(method);

            foreach (var testCommand in cmds)
            {
                yield return testCommand;
            }

        }
    }
}
