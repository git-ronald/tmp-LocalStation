using CoreLibrary;
using CoreLibrary.Helpers;
using CoreLibrary.SchedulerService;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class TimeCompartmentSchedulerConfig : PeerCompartmentConfig //ISchedulerConfig<object, TimeCompartments>
    {
        //public TimeCompartmentSchedulerConfig()
        //{
        //    //Tasks[TimeCompartments.Every2Minutes] = new()
        //    //{
        //    //    ScheduleEvery2Minutes1,
        //    //    ScheduleEvery2Minutes2,
        //    //};

        //    //Tasks[TimeCompartments.Every3Minutes] = new()
        //    //{
        //    //    ScheduleEvery3Minutes
        //    //};

        //    Tasks.Ensure(TimeCompartments.Every2Minutes).AddItems(
        //        ScheduleEvery2Minutes1,
        //        ScheduleEvery2Minutes2);

        //    Tasks.Ensure(TimeCompartments.Every3Minutes).AddItems(
        //        ScheduleEvery3Minutes);
        //}

        public override Dictionary<TimeCompartments, SchedulerTaskList> BuildSchedule<TState>(TState? state = null) where TState : class
        {
            var schedule = base.BuildSchedule<TState>(state);
            schedule.Ensure(TimeCompartments.EveryMinute).Add(
                token =>
                {
                    Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every minute by TestApp");
                    return Task.CompletedTask;
                });

            return schedule;
        }
    }
}
