using LocalStation;
using PeerLibrary.Configuration;

try
{
    Console.WriteLine("Initializing...");
    Console.WriteLine();

    await Startup.ConfigureServices().StartHubClient();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
