using CoreLibrary.Helpers;
using CoreLibrary.SchedulerService;
using PeerLibrary.Data;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class FixedTimeSchedulerConfig : PeerFixedTimeConfig
    {
        public override async Task<Dictionary<TimeSpan, SchedulerTaskList>> BuildSchedule(SchedulerState state)
        {
            var schedule = await base.BuildSchedule(state);
            return schedule;
        }
    }
}
