using CoreLibrary;
using CoreLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;
using PeerLibrary.Scheduler;
using PeerLibrary.Settings;
using TestAppLibrary.Data;
using TestAppLibrary.Scheduler;

namespace TestAppLibrary.Configuration;

public class ServiceConfiguration : IPeerServiceConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        return services.AddJsonConfiguration("testapp.settings.json").Configure<PeerSettings>("peerSettings")
            .AddDbContext<TestDbContext>()
            .AddTransient<ISchedulerConfig<TimeSpan>, FixedTimeSchedulerConfig>()
            .AddTransient<ISchedulerConfig<TimeCompartments>, TimeCompartmentSchedulerConfig>();
    }
}
