using Bonsai.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Bonsai.Components.Goals.Editor
{
	public partial class AssignmentEditor : IGoalEditorComponent<AssignmentGoal>
	{
		private EditContext? editContext;
		private bool isInitialized;

		[Parameter]
		public AssignmentGoal? Goal { get; set; }

		public bool TrySubmit(out AssignmentGoal? goal)
		{
			if (!isInitialized) throw new InvalidOperationException();

			if (!editContext!.Validate())
			{
				goal = null;

				return false;
			}

			goal = Goal;

			return true;
		}

		protected override void OnInitialized()
		{
			Goal ??= new AssignmentGoal { CommencementTime = DateTime.Now, Deadline = DateTime.Today.AddDays(1), Title = "", Description = "", SubGoals = new List<Goal>() };
			editContext = new EditContext(Goal);
			isInitialized = true;

			base.OnInitialized();
		}
	}
}