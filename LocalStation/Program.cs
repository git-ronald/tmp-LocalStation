using LocalStation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;
using TestAppLibrary.Data;

try
{
    Console.WriteLine("Initializing...");
    Console.WriteLine();

    await Startup.ConfigureServices().StartHubClient(scope =>
    {
        scope.ServiceProvider.GetRequiredService<TestDbContext>().Database.MigrateAsync();
    });
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
