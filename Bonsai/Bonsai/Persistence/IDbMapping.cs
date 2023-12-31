using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence
{
	public interface IDbMapping
	{
		void BuildMapping(ModelBuilder modelBuilder);
	}
}
