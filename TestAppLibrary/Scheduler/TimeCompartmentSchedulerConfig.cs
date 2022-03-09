using CoreLibrary;
using CoreLibrary.Helpers;
using CoreLibrary.SchedulerService;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class TimeCompartmentSchedulerConfig : PeerCompartmentConfig
    {
        public override Dictionary<TimeCompartments, SchedulerTaskList> BuildSchedule(SchedulerState state)
        {
            var schedule = base.BuildSchedule(state);
            //schedule.Ensure(TimeCompartments.EveryMinute).Add(
            //    token =>
            //    {
            //        Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every minute by TestApp");
            //        return Task.CompletedTask;
            //    });

            return schedule;
        }
    }
}
