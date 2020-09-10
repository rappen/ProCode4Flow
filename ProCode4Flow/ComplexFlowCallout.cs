using Jonas;

namespace ProCode4Flow
{
    public class ProCodeEscape : JonasPluginBase
    {
        public override void Execute(JonasPluginBag bag)
        {
            var json = bag.PluginContext.GetInputParameterForgiving<string>("SomeJSON");
            var extra = bag.PluginContext.GetInputParameterForgiving<bool>("ExtraMagic");

            if (string.IsNullOrWhiteSpace(json))
            {
                bag.PluginContext.OutputParameters.AddOrUpdateIfNotNull("ErrorCode", 1);
                bag.PluginContext.OutputParameters.AddOrUpdateIfNotNull("ErrorMessage", "JSON is empty");
                return;
            }
            var result = json.DoTheFancyMagicStuff(extra);
            bag.PluginContext.OutputParameters.AddOrUpdateIfNotNull("ResultJSON", result);
        }
    }

    public static class Helpers
    {
        public static string DoTheFancyMagicStuff(this string json, bool extra)
        {
            // Pro Code Magic
            return json;
        }
    }
}
