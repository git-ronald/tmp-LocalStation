using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.PeerApp.Interfaces;
using TestAppLibrary.Data;

namespace TestAppLibrary;

public class Startup : IPeerStartup
{
    public Task MigrateDatabase(AsyncServiceScope scope) => scope.ServiceProvider.GetRequiredService<TestDbContext>().Database.MigrateAsync();
}
