using Bonsai.Model;

namespace Bonsai.Components.Goals
{
	public interface IGoalEditorComponent<TGoal> : IGoalComponent<TGoal> where TGoal : Goal
    {
    }
}
