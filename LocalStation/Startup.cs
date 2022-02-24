using LocalStation.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;

namespace LocalStation
{
    internal static class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AdddJsonConfiguration("appsettings.json")
                .Configure<MainSettings>("mainSettings")
                .AddPeerLibrary()
                .BuildServiceProvider();
        }
    }
}
