using Bonsai.Model;
using Microsoft.AspNetCore.Components;

namespace Bonsai.Components.Goals.Editor
{
	public partial class AppointmentEditor : IGoalEditorComponent<AppointmentGoal>
	{
		[Parameter]
		public AppointmentGoal? Goal { get; set; }

		public bool TrySubmit(out AppointmentGoal? goal)
		{
			throw new NotImplementedException();
		}
	}
}