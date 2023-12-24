using Bonsai.Model;
using Microsoft.AspNetCore.Components;

namespace Bonsai.Components.Goals.Details
{
    public partial class AssignmentDetails : IGoalDetailsComponent<AssignmentGoal>
    {
        [Parameter]
        public required AssignmentGoal Goal { get; set; }
    }
}