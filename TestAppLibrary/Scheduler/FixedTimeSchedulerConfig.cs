using CoreLibrary.SchedulerService;

namespace TestAppLibrary.Scheduler
{
    internal class FixedTimeSchedulerConfig : ISchedulerConfig<object, TimeSpan>
    {
        public FixedTimeSchedulerConfig()
        {
            Tasks[new TimeSpan(18, 55, 0)] = new()
            {
                (token, state) =>
                {
                    Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} FIXED TIME!");
                    return Task.CompletedTask;
                }
            };
        }

        public Dictionary<TimeSpan, List<ScheduledTaskDelegate<object>>> Tasks { get; } = new();
    }
}
