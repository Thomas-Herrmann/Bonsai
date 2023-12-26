namespace Bonsai.Injection
{
	public record GoalMeta
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public required string IconPath { get; set; }
	}
}