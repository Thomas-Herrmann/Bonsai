using Bonsai.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bonsai.Persistence
{
	public abstract class GoalDbMapping<TGoal> : IDbMapping where TGoal : Goal
	{
		public void BuildMapping(ModelBuilder modelBuilder) => BuildMapping(modelBuilder.Entity<TGoal>());

		protected abstract void BuildMapping(EntityTypeBuilder<TGoal> mappingBuilder);
	}

	public class AssignmentDbMapping : GoalDbMapping<AssignmentGoal>
	{
		protected override void BuildMapping(EntityTypeBuilder<AssignmentGoal> mappingBuilder)
		{
			mappingBuilder.Property(_ => _.Title).UseCollation("nocase");
			mappingBuilder.Property(_ => _.Description);
		}
	}
}
