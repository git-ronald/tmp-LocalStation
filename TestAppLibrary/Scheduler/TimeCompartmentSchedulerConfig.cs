using CoreLibrary;
using CoreLibrary.SchedulerService;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class TimeCompartmentSchedulerConfig : PeerCompartmentConfig
    {
        public override async Task<Dictionary<TimeCompartments, SchedulerTaskList>> BuildSchedule(SchedulerState state)
        {
            var schedule = await base.BuildSchedule(state);
            return schedule;
        }
    }
}
