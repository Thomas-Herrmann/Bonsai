namespace Bonsai.Model
{
    public interface IGoalComponent<TGoal> where TGoal : Goal
    {
        TGoal Goal { get; set; }
    }
}
