using CoreLibrary;
using CoreLibrary.SchedulerService;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;
using PeerLibrary.Scheduler;
using PeerLibrary.Settings;
using TestAppLibrary.Data;
using TestAppLibrary.Scheduler;

namespace TestAppLibrary.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTestApp(this IServiceCollection services)
        {
            return services.AddJsonConfiguration("testapp.settings.json").Configure<PeerSettings>("peerSettings")
                .AddDbContext<TestDbContext>()
                .AddTransient<ISchedulerConfig<SchedulerState, TimeSpan>, FixedTimeSchedulerConfig>()
                .AddTransient<ISchedulerConfig<SchedulerState, TimeCompartments>, TimeCompartmentSchedulerConfig>();
        }
    }
}
