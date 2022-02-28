using LocalStation.Settings;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;

namespace LocalStation
{
    internal static class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddJsonConfiguration("appsettings.json")
                .Configure<MainSettings>("mainSettings")
                .AddPeerLibrary()
                .BuildServiceProvider();
        }
    }
}
