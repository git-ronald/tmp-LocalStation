
namespace LocalStation
{
    internal interface IHubClient : IAsyncDisposable
    {
        Task Start();
        Task Test();
    }
}