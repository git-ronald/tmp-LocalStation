using CoreLibrary;
using CoreLibrary.SchedulerService;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;
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
                .AddTransient<ISchedulerConfig<object, TimeSpan>, FixedTimeSchedulerConfig>()
                .AddTransient<ISchedulerConfig<object, TimeCompartments>, TimeCompartmentSchedulerConfig>();
        }
    }
}
