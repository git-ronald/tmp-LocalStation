using LocalStation;

static IHubClient? Startup()
{
    try
    {
        Console.WriteLine("Initializing...");
        return Services.Create().Get<IHubClient>();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
}

await using IHubClient? hubClient = Startup();
if (hubClient != null)
{
    try
    {
        Console.WriteLine("Starting Hub client...");
        await hubClient.Start();
        Console.WriteLine("Hub client started.");
        await hubClient.Test();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to start Hub client: {ex.Message}");
    }
}

Console.Write("Press Escape to quit: ");
while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
}
