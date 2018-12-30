using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Flowsharp.Activities;
using Flowsharp.Models;
using Flowsharp.Results;
using Microsoft.Extensions.Localization;

namespace Flowsharp.Handlers
{
    public class UnknownActivityHandler : ActivityHandler<UnknownActivity>
    {
        public UnknownActivityHandler(IStringLocalizer<UnknownActivityHandler> localizer)
        {
            T = localizer;
        }

        public IStringLocalizer<UnknownActivityHandler> T { get; }
        public override LocalizedString Category => T["System"];
        public override IEnumerable<LocalizedString> GetEndpoints() => Enumerable.Empty<LocalizedString>();
        
        protected override ActivityExecutionResult OnExecute(UnknownActivity activity, WorkflowExecutionContext workflowContext)
        {
            return Fault($"Unknown activity: {activity.Name}, ID: {activity.Id}");
        }
    }
}