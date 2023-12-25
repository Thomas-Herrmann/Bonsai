using Bonsai.Model;
using Microsoft.AspNetCore.Components;

namespace Bonsai.Components.Goals.Summary
{
    public partial class AssignmentListSummary : IListSummaryGoalComponent<AssignmentGoal>
    {
        [Parameter]
        public required AssignmentGoal Goal { get; set; }
    }
}