﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18052
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tester
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class IgnoreThisFeatureFeature : Xunit.IUseFixture<IgnoreThisFeatureFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "IgnoreThisFeature.feature"
#line hidden
        
        public IgnoreThisFeatureFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "IgnoreThisFeature", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, new string[] {
                        "IgnoreLocally"});
            testRunner.OnFeatureStart(featureInfo);
//More info on this add-in available at
//https://github.com/chrismckelt/SpecFlowCustomPlugin
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            if (McKeltCustom.SpecflowPlugin.Settings.ShouldIgnoreLocally())
            {
                // https://github.com/chrismckelt/SpecFlowCustomPlugin
            }
            else
            {
                // https://github.com/chrismckelt/SpecFlowCustomPlugin
return;
            }
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            if (McKeltCustom.SpecflowPlugin.Settings.ShouldIgnoreLocally())
            {
                // https://github.com/chrismckelt/SpecFlowCustomPlugin
            }
            else
            {
                // https://github.com/chrismckelt/SpecFlowCustomPlugin
return;
            }
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(IgnoreThisFeatureFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [McKeltCustom.SpecflowPlugin.OptionallyIgnoreTestFactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "IgnoreThisFeature")]
        [Xunit.TraitAttribute("Description", "Add two numbers")]
        public virtual void AddTwoNumbers()
        {
            McKeltCustom.SpecflowPlugin.Settings.IgnoreLocally = null;
            McKeltCustom.SpecflowPlugin.Settings.ShouldTestRun("IgnoreLocallyxx");
            if (McKeltCustom.SpecflowPlugin.Settings.ShouldIgnoreLocally())
            {
                // https://github.com/chrismckelt/SpecFlowCustomPlugin
            }
            else
            {
                // https://github.com/chrismckelt/SpecFlowCustomPlugin
return;
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two numbers", new string[] {
                        "IgnoreLocallyxx"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I have entered 50 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I have entered 70 into the calculator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("the result should be 120 on the screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                IgnoreThisFeatureFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                IgnoreThisFeatureFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
