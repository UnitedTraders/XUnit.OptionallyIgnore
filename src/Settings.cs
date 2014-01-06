using System.Linq;
using TechTalk.SpecFlow;

namespace XUnit.OptionallyIgnore.SpecFlowPlugin
{
    public static class Settings
    {
        public const string OptionallyIgnoreTag = "OptionallyIgnore";
        public static bool? OptionallyIgnore { get; set; }

        public static bool ShouldOptionallyIgnore()
        {

            if (OptionallyIgnore.HasValue && OptionallyIgnore.Value) return OptionallyIgnore.Value;

            bool ignore = false;

            if (ScenarioContext.Current != null)
            {
                if (ScenarioContext.Current.ScenarioInfo != null)
                    if (ScenarioContext.Current.ScenarioInfo.Tags != null)
                        ignore = ScenarioContext.Current.ScenarioInfo.Tags.Contains(OptionallyIgnoreTag);

                if (ignore)
                {
                    return false;
                }
            }


            if (FeatureContext.Current != null)
            {
                if (FeatureContext.Current.FeatureInfo != null)
                    if (FeatureContext.Current.FeatureInfo.Tags != null)
                        ignore = FeatureContext.Current.FeatureInfo.Tags.Contains(OptionallyIgnoreTag);

                if (ignore)
                {
                    return false;
                }
            }

            return true;
        }


        public static void ShouldTestRun(string tagToIgnore)
        {
            if (string.IsNullOrEmpty(tagToIgnore)) return;

            if (tagToIgnore.ToLower() == OptionallyIgnoreTag.ToLower())
            {
                OptionallyIgnore = false;
            }

        }
    }
}
