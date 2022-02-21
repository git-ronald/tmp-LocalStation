using LocalStation.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocalStation
{
    internal class Services
    {
        private readonly IServiceProvider _serviceProvider;

        private Services(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static Services Create()
        {
            IConfiguration? configuration = GetConfiguration();
            if (configuration == null)
            {
                throw new Exception("Failed to build configuration.");
            }

            ServiceProvider serviceProvider = new ServiceCollection()
                .Configure<HubSettings>(configuration.GetSection("hub"))
                .AddTransient<IHubClient, HubClient>()
                .BuildServiceProvider();

            return new Services(serviceProvider);
        }

        private static IConfiguration? GetConfiguration()
        {
            var dirInfo = Directory.GetParent(AppContext.BaseDirectory);
            if (dirInfo == null)
            {
                return null;
            }

            return new ConfigurationBuilder().SetBasePath(dirInfo.FullName).AddJsonFile("appsettings.json").Build();
        }

        public TService Get<TService>()
        {
            TService? service = _serviceProvider.GetService<TService>();
            if (service == null)
            {
                throw new Exception($"Failed to create service {typeof(TService).Name}.");
            }

            return service;
        }
    }
}
