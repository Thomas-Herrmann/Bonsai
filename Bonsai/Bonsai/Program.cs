using Bonsai.Client.Pages;
using Bonsai.Components;
using Bonsai.Components.Goals.Details;
using Bonsai.Components.Goals.Summary;
using Bonsai.Injection;
using Bonsai.Model;

namespace Bonsai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new ComponentInjector();

            RegisterComponents(container);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddCascadingValue(_ => container);

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

        private static void RegisterComponents(ComponentInjector injector)
        {
            injector.For<AssignmentGoal>().OfKind<IGoalDetailsComponent<AssignmentGoal>>().Inject<AssignmentDetails>();
            injector.For<AssignmentGoal>().OfKind<IListSummaryGoalComponent<AssignmentGoal>>().Inject<AssignmentListSummary>();
        }
    }
}
