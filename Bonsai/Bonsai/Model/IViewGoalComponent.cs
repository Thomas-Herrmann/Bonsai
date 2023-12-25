namespace Bonsai.Model
{
    public interface IViewGoalComponent<TGoal> : IGoalComponent<TGoal> where TGoal : Goal
    {
        TGoal Goal { get; set; }
    }
}
