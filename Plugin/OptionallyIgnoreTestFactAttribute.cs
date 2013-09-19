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
    public class OptionallyIgnoreTestFactAttribute : FactAttribute
    {
        // private static readonly string _logFile = Path.Combine(@"c:\", "test.log");


        public OptionallyIgnoreTestFactAttribute()
        {
            WriteLog("OptionallyIgnoreTestFactAttribute Ctor");

            if (McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally.HasValue &&
                McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally == true)
                this.Skip = "Test Ignored at runtime";
        }

        protected override IEnumerable<Xunit.Sdk.ITestCommand> EnumerateTestCommands(Xunit.Sdk.IMethodInfo method)
        {
            WriteLog("Start");
            bool ignore = false;
            if (ScenarioContext.Current != null)
            {
                if (ScenarioContext.Current.ScenarioInfo != null)
                    if (ScenarioContext.Current.ScenarioInfo.Tags != null)
                        ignore = ScenarioContext.Current.ScenarioInfo.Tags.Contains(Settings.IgnoreLocallyTag);

                if (ignore)
                {
                    WriteLog("ignore true");

                    yield return new SkipCommand(method, ScenarioContext.Current.ScenarioInfo.Title, "Test Ignored: " + Settings.IgnoreLocallyTag);
                }
            }


            if (FeatureContext.Current != null)
            {
                if (FeatureContext.Current.FeatureInfo != null)
                    if (FeatureContext.Current.FeatureInfo.Tags != null)
                        ignore = FeatureContext.Current.FeatureInfo.Tags.Contains(Settings.IgnoreLocallyTag);

                if (ignore)
                {
                    WriteLog("ignore true");

                    yield return new SkipCommand(method, FeatureContext.Current.FeatureInfo.Title, "Test Ignored: " + Settings.IgnoreLocallyTag);
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
