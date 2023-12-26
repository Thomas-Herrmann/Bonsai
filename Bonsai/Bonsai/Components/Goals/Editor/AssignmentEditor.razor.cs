using Bonsai.Model;
using Microsoft.AspNetCore.Components;

namespace Bonsai.Components.Goals.Editor
{
	public partial class AssignmentEditor : IGoalEditorComponent<AssignmentGoal>
	{
		[Parameter]
		public AssignmentGoal? Goal { get; set; }
	}
}