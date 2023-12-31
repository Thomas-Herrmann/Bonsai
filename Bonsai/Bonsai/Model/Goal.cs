namespace Bonsai.Model
{
    public class Goal
    {
        public required string Title { get; set; }
        public required string Description { get; set; }

        public Guid Id { get; set; }
    }
}
