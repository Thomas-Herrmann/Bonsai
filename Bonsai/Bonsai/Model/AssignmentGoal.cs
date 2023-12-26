namespace Bonsai.Model
{
    public class AssignmentGoal : CompositeGoal
    {
        public required DateTime Deadline { get; set; }
        public required DateTime CommencementTime { get; set; }
	}
}