using LocalStation;
using PeerLibrary;
using PeerLibrary.Configuration;

try
{
    Console.WriteLine("Initializing...");
    Console.WriteLine();

    await Startup.ConfigureServices().GetServiceOrThrow<IHubClient>().Start();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
