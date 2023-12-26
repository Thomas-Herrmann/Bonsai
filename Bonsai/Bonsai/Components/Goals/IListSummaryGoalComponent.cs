using Bonsai.Model;

namespace Bonsai.Components.Goals
{
    public interface IListSummaryGoalComponent<TGoal> : IViewGoalComponent<TGoal> where TGoal : Goal
    {
    }
}
