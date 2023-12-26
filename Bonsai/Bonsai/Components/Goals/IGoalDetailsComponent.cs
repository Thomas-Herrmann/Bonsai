using Bonsai.Model;

namespace Bonsai.Components.Goals
{
	public interface IGoalDetailsComponent<TGoal> : IViewGoalComponent<TGoal> where TGoal : Goal
    {
    }
}
