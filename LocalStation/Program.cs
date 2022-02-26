using LocalStation;
using Microsoft.Extensions.DependencyInjection;
using PeerLibrary;

static IHubClient? Start()
{
    try
    {
        Console.WriteLine("Initializing...");
        var serviceProvider = Startup.ConfigureServices();
        return serviceProvider.GetService<IHubClient>();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
}

await using IHubClient? hubClient = Start();
if (hubClient != null)
{
    try
    {
        Console.WriteLine("Starting Hub client...");
        await hubClient.Start();

        Console.WriteLine();
        Console.WriteLine("Hub client started.");
        Console.WriteLine("Press Escape to quit.");
        Console.WriteLine();

        await hubClient.Test();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to start Hub client: {ex.Message}");
    }
}

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (key.Key == ConsoleKey.Enter && hubClient != null)
    {
        await hubClient.Test();
    }
}
