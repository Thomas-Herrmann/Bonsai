using Bonsai.Model;
using Microsoft.AspNetCore.Components;

namespace Bonsai.Components.Goals.Editor
{
	public partial class AssignmentEditor : IGoalEditorComponent<AssignmentGoal>
	{
		[Parameter]
		public AssignmentGoal? Goal { get; set; }

		protected override void OnInitialized()
		{
			Goal ??= new AssignmentGoal { CommencementTime = DateTime.Now, Deadline = DateTime.Today.AddDays(1), Title = "", Description = "", SubGoals = new List<Goal>() };

			base.OnInitialized();
		}

		private async Task CreateAsync()
		{
			await unitOfWork.AddGoalAsync(Goal!);
		}
	}
}