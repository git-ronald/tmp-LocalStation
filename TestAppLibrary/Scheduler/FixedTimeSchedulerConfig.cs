using CoreLibrary.Helpers;
using CoreLibrary.SchedulerService;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class FixedTimeSchedulerConfig : PeerFixedTimeConfig
    {
        public override Dictionary<TimeSpan, SchedulerTaskList> BuildSchedule(SchedulerState state)
        {
            var schedule = base.BuildSchedule(state);

            //var existingEvent = schedule.First();
            //existingEvent.Value.Add(
            //    token =>
            //    {
            //        Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 1 by TestApp {existingEvent.Key}");
            //        return Task.CompletedTask;
            //    });

            //var nextEventTime = DateTime.UtcNow.Apply(existingEvent.Key, 0).AddMinutes(1).TimeOfDay;
            //schedule.Ensure(nextEventTime).Add(
            //    token =>
            //    {
            //        Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 2 by TestApp {nextEventTime}");
            //        return Task.CompletedTask;
            //    });

            return schedule;
        }
    }
}
