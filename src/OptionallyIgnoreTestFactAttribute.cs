using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Sdk;

namespace XUnit.OptionallyIgnore.SpecFlowPlugin
{
    public class OptionallyIgnoreTestFactAttribute : FactAttribute
    {
        // private static readonly string _logFile = Path.Combine(@"c:\", "test.log");


        public OptionallyIgnoreTestFactAttribute()
        {
            WriteLog("OptionallyIgnoreTestFactAttribute Ctor");

            if (Settings.OptionallyIgnore.HasValue &&
                Settings.OptionallyIgnore == true)
                this.Skip = "Optionally Ignored at runtime - Settings.OptionallyIgnore=true";
        }

        protected override IEnumerable<Xunit.Sdk.ITestCommand> EnumerateTestCommands(Xunit.Sdk.IMethodInfo method)
        {
            WriteLog("Start");
            bool ignore = false;
            if (ScenarioContext.Current != null)
            {
                if (ScenarioContext.Current.ScenarioInfo != null)
                    if (ScenarioContext.Current.ScenarioInfo.Tags != null)
                        ignore = ScenarioContext.Current.ScenarioInfo.Tags.Contains(Settings.OptionallyIgnoreTag);

                if (ignore)
                {
                    WriteLog("ignore true");

                    yield return new SkipCommand(method, ScenarioContext.Current.ScenarioInfo.Title, "Test Ignored: " + Settings.OptionallyIgnoreTag);
                }
            }


            if (FeatureContext.Current != null)
            {
                if (FeatureContext.Current.FeatureInfo != null)
                    if (FeatureContext.Current.FeatureInfo.Tags != null)
                        ignore = FeatureContext.Current.FeatureInfo.Tags.Contains(Settings.OptionallyIgnoreTag);

                if (ignore)
                {
                    WriteLog("ignore true");

                    yield return new SkipCommand(method, FeatureContext.Current.FeatureInfo.Title, "Test Ignored: " + Settings.OptionallyIgnoreTag);
                }
            }


            WriteLog("EnumerateTestCommands");
            var cmds = base.EnumerateTestCommands(method);
            WriteLog("get ready for yield return");
            foreach (var testCommand in cmds)
            {
                yield return testCommand;
            }

        }

        private static void WriteLog(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
           
            //File.AppendAllText(_logFile, msg + System.Environment.NewLine);
        }
    }
}
