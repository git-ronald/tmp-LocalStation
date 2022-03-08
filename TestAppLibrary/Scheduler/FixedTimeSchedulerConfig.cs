using CoreLibrary.Helpers;
using CoreLibrary.SchedulerService;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class FixedTimeSchedulerConfig : PeerFixedTimeConfig
    {
        public override Dictionary<TimeSpan, SchedulerTaskList> BuildSchedule<TState>(TState? state = default) where TState : class
        {
            var schedule = base.BuildSchedule(state);

            var existingEvent = schedule.First();
            existingEvent.Value.Add(
                token =>
                {
                    Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 1 by TestApp {existingEvent.Key}");
                    return Task.CompletedTask;
                });

            var nextEventTime = DateTime.UtcNow.Apply(existingEvent.Key, 0).AddMinutes(1).TimeOfDay;
            schedule.Ensure(nextEventTime).Add(
                token =>
                {
                    Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 2 by TestApp {nextEventTime}");
                    return Task.CompletedTask;
                });

            return schedule;
        }
        //public override Dictionary<TimeSpan, SchedulerTaskList> BuildSchedule<TState>(TState? state = default(TState)) where TState : notnull
        //{
        //    var schedule = base.BuildSchedule<TState>(state);
        //    return schedule;
        //}
        //public FixedTimeSchedulerConfig()
        //{
        //    Tasks.Ensure(new TimeSpan(21, 14, 0)).AddItems(
        //        (token, state) =>
        //        {
        //            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 1 by TestApp");
        //            return Task.CompletedTask;
        //        });
        //    Tasks.Ensure(new TimeSpan(21, 15, 0)).AddItems(
        //        (token, state) =>
        //        {
        //            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Fixed time 2 by TestApp");
        //            return Task.CompletedTask;
        //        });
        //}
    }
}
