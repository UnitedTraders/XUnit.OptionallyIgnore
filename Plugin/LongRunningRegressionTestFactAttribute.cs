using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Sdk;

namespace McKeltCustom.SpecflowPlugin
{
    public class LongRunningRegressionTestFactAttribute : FactAttribute
    {
        private static readonly string _logFile = Path.Combine(@"c:\", "test.log");
        public const string LongRunningTest = "LongRunningTest";
        public const string OnlyRunOnBuildServer = "OnlyRunOnBuildServer";
        public const string LongRunningRegressionTest = "LongRunningRegressionTest";
        public const string IgnoreLocally = "IgnoreLocally";

        public LongRunningRegressionTestFactAttribute()
        {
#if DEBUG
            //File.Delete(_logFile);
            //File.Create(_logFile);


            WriteLog("LongRunningRegressionTestFactAttribute Ctor");
#endif

        }

        protected override IEnumerable<Xunit.Sdk.ITestCommand> EnumerateTestCommands(Xunit.Sdk.IMethodInfo method)
        {
            WriteLog("Start");
            bool ignore = false;
            if (ScenarioContext.Current != null)
            {
                if (ScenarioContext.Current.ScenarioInfo != null)
                    if (ScenarioContext.Current.ScenarioInfo.Tags != null)
                        ignore = ScenarioContext.Current.ScenarioInfo.Tags.Contains(LongRunningTest) ||
                                 ScenarioContext.Current.ScenarioInfo.Tags.Contains(OnlyRunOnBuildServer) ||
                                 ScenarioContext.Current.ScenarioInfo.Tags.Contains(LongRunningRegressionTest) ||
                                 ScenarioContext.Current.ScenarioInfo.Tags.Contains(IgnoreLocally);
            }

            if (ignore)
            {
                WriteLog("ignore true");
                string msg = ScenarioContext.Current.ScenarioInfo.Tags.Aggregate(string.Empty, (current, tag) => current + (tag + " : "));

                yield return new SkipCommand(method, ScenarioContext.Current.ScenarioInfo.Title, "Test Ignored: " + msg);
            }

            WriteLog("keep going");
            var cmds = base.EnumerateTestCommands(method);
            WriteLog("get ready for yield return");
            foreach (var testCommand in cmds)
            {
                yield return testCommand;
            }

        }

        private static void WriteLog(string msg)
        {
#if DEBUG
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
           
            //File.AppendAllText(_logFile, msg + System.Environment.NewLine);
#endif
        }
    }
}
