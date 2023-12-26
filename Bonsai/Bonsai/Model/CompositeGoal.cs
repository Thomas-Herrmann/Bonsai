namespace Bonsai.Model
{
    public class CompositeGoal : Goal
    {
        public required IList<Goal> SubGoals { get; set; }
    }
}