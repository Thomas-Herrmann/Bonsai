using Bonsai.Model;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence
{
	public class UnitOfWork
    {
		private readonly IDbContextFactory<GoalContext> dbContextFactory;
		private readonly Task setupTask;

		public UnitOfWork(IDbContextFactory<GoalContext> dbContextFactory)
		{
			this.dbContextFactory = dbContextFactory;

            setupTask = SetupDatabase();
		}

        private async Task SetupDatabase()
        {
			using var dbContext = await dbContextFactory.CreateDbContextAsync();

			await dbContext.Database.EnsureCreatedAsync();
		}

        public async Task AddGoalAsync(Goal goal)
        {
            await setupTask;

			using GoalContext dbContext = await dbContextFactory.CreateDbContextAsync();

            await dbContext.AddAsync(goal);
		}

		public async Task UpdateGoalAsync(Goal goal)
		{
			await setupTask;

			using GoalContext dbContext = await dbContextFactory.CreateDbContextAsync();

			dbContext.Update(goal);
		}

		public async Task RemoveGoalAsync(Goal goal)
		{
			await setupTask;

			using GoalContext dbContext = await dbContextFactory.CreateDbContextAsync();

			dbContext.Remove(goal);
		}

        public async Task<GoalQuerrier> MakeGoalQueryAsync()
        {
			await setupTask;

			GoalContext dbContext = await dbContextFactory.CreateDbContextAsync();

            return new GoalQuerrier(await dbContextFactory.CreateDbContextAsync());
		}

        public sealed class GoalQuerrier : IAsyncDisposable
        {
			private readonly GoalContext dbContext;

			public GoalQuerrier(GoalContext dbContext)
            {
				this.dbContext = dbContext;
			}

            public IQueryable<Goal> Goals => dbContext.Goals;

            public ValueTask DisposeAsync() => dbContext.DisposeAsync();
		}
	}
}