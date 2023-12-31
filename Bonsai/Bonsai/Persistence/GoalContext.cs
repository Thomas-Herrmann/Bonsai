using Bonsai.Injection;
using Bonsai.Model;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence
{
	public class GoalContext : DbContext, IAsyncDisposable
    {
        private readonly GoalInjector container;
        private bool isDisposed;

        public DbSet<Goal> Goals { get; set; } = default!;

        public static string DatabaseName => "bonsai.db";

        public GoalContext(GoalInjector container, DbContextOptions<GoalContext> options) : base(options)
        {
            this.container = container;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Goal>().HasKey(_ => _.Id);
            modelBuilder.Entity<Goal>().Property(_ => _.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Goal>().ToTable(nameof(Goal));

            foreach (IDbMapping mapping in container.GetDbMappings()) mapping.BuildMapping(modelBuilder);
        }

        public override void Dispose()
        {
            if (isDisposed) return;

            isDisposed = true;

            SaveChanges();
            base.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            if (isDisposed) return;

            isDisposed = true;

            await SaveChangesAsync();
            await base.DisposeAsync();
        }
    }
}