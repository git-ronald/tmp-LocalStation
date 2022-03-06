using CoreLibrary.Helpers;
using CoreLibrary.SchedulerService;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class FixedTimeSchedulerConfig : PeerFixedTimeSchedulerConfig
    {
        public FixedTimeSchedulerConfig()
        {
            Tasks.Ensure(new TimeSpan(21, 14, 0)).AddItems(
                (token, state) =>
                {
                    Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 1 by TestApp");
                    return Task.CompletedTask;
                });
            Tasks.Ensure(new TimeSpan(21, 15, 0)).AddItems(
                (token, state) =>
                {
                    Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 2 by TestApp");
                    return Task.CompletedTask;
                });
        }
    }
}
