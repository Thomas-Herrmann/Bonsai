using Bonsai.Model;

namespace Bonsai.Components.Goals
{
    public interface IViewGoalComponent<TGoal> : IGoalComponent<TGoal> where TGoal : Goal
    {
        TGoal Goal { get; set; }
    }
}
