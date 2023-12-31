using Bonsai.Client.Pages;
using Bonsai.Components;
using Bonsai.Components.Goals;
using Bonsai.Components.Goals.Details;
using Bonsai.Components.Goals.Editor;
using Bonsai.Components.Goals.Summary;
using Bonsai.Injection;
using Bonsai.Model;
using Bonsai.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bonsai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new GoalInjector();

            RegisterComponents(container);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddDbContextFactory<GoalContext>(_ => _.UseSqlite($"Data Source={GoalContext.DatabaseName}"));
            builder.Services.AddQuickGridEntityFrameworkAdapter();
			builder.Services.AddSingleton(container);
            builder.Services.AddScoped<UnitOfWork>();

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Counter).Assembly);

            app.Run();
        }

        private static void RegisterComponents(GoalInjector injector)
        {
            injector.For<AssignmentGoal>().OfKind<IGoalDetailsComponent<AssignmentGoal>>().Inject<AssignmentDetails>();
            injector.For<AssignmentGoal>().OfKind<IListSummaryGoalComponent<AssignmentGoal>>().Inject<AssignmentListSummary>();
            injector.For<AssignmentGoal>().OfKind<IGoalEditorComponent<AssignmentGoal>>().Inject<AssignmentEditor>();
            injector.For<AssignmentGoal>().InjectMeta(new GoalMeta { Name = "Assignment", Description = "A task that must be completed due a specified deadline", IconPath = "/images/deadline.png" });
            injector.For<AssignmentGoal>().InjectDbMapping(new AssignmentDbMapping());

            injector.For<AppointmentGoal>().OfKind<IGoalEditorComponent<AppointmentGoal>>().Inject<AppointmentEditor>();
            injector.For<AppointmentGoal>().InjectMeta(new GoalMeta { Name = "Appointment", Description = "A task that must be completed at a specified time", IconPath = "/images/deadline.png" });
        }
    }
}
