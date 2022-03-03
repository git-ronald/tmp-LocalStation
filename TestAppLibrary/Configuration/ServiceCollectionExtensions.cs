using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;
using PeerLibrary.Settings;

namespace TestAppLibrary.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTestApp(this IServiceCollection services)
        {
            return services.AddJsonConfiguration("testapp.settings.json").Configure<PeerSettings>("peerSettings");
        }
    }
}
