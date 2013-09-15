using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit.Sdk;

namespace McKeltCustom.SpecflowPlugin
{
    public static class Settings
    {
        public const string IgnoreLocallyTag = "IgnoreLocally";
        public static bool? IgnoreLocally { get; set; }

        public static bool ShouldIgnoreLocally()
        {
            
            if (IgnoreLocally.HasValue) return IgnoreLocally.Value;

            bool ignore = false;

            if (ScenarioContext.Current != null)
            {
                if (ScenarioContext.Current.ScenarioInfo != null)
                    if (ScenarioContext.Current.ScenarioInfo.Tags != null)
                        ignore = ScenarioContext.Current.ScenarioInfo.Tags.Contains(IgnoreLocallyTag);

                if (ignore)
                {
                    return false;
                }
            }


            if (FeatureContext.Current != null)
            {
                if (FeatureContext.Current.FeatureInfo != null)
                    if (FeatureContext.Current.FeatureInfo.Tags != null)
                        ignore = FeatureContext.Current.FeatureInfo.Tags.Contains(IgnoreLocallyTag);

                if (ignore)
                {
                    return false;
                }
            }

            return true;
        }


        public static void ShouldTestRun(string tagToIgnore)
        {
            if (tagToIgnore.ToLower() == IgnoreLocallyTag.ToLower())
            {
                IgnoreLocally = false;
            }

        }
    }
}
