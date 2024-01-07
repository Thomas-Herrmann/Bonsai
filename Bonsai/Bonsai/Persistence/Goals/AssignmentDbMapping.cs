using Bonsai.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bonsai.Persistence.Goals
{
    public class AssignmentDbMapping : GoalDbMapping<AssignmentGoal>
    {
        protected override void BuildMapping(EntityTypeBuilder<AssignmentGoal> mappingBuilder)
        {
            
        }
    }
}
