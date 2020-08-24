using Jonas;
using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace ProCode4Flow
{
    public class ComplexFlowCallout : JonasPluginBase
    {
        public override void Execute(JonasPluginBag bag)
        {
            var json = bag.PluginContext.GetInputParameterForgiving<string>("JSONblob");
            var action = bag.PluginContext.GetInputParameterForgiving<OptionSetValue>("Action");

            switch (action?.Value)
            {
                case 0:
                    json = json.Replace("{", "<").Replace("}", ">");
                    break;
                case 1:
                    json = json.ToLowerInvariant();
                    break;
                case 3:
                    json = json.Substring(0, Math.Min(10, json.Length));
                    break;
                default:
                    bag.PluginContext.OutputParameters.AddOrUpdateIfNotNull("ErrorCode", 1);
                    bag.PluginContext.OutputParameters.AddOrUpdateIfNotNull("ErrorMessage", $"Invalid Action: {action.Value}");
                    return;
            }
            bag.PluginContext.OutputParameters.AddOrUpdateIfNotNull("ProCodeResult", json);
        }
    }
}
