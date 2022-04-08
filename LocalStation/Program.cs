using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;

// TODO: PeerLibrary should catch all errors
Console.WriteLine("Initializing...");
Console.WriteLine();

await new ServiceCollection().ConfigureAppServices().StartHubClient();
