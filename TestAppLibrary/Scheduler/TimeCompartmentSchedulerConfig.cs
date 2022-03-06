using CoreLibrary;
using CoreLibrary.SchedulerService;

namespace TestAppLibrary.Scheduler
{
    internal class TimeCompartmentSchedulerConfig : ISchedulerConfig<object, TimeCompartments>
    {
        public TimeCompartmentSchedulerConfig()
        {
            Tasks[TimeCompartments.EveryMinute] = new()
            {
                ScheduleEveryMinute
            };

            Tasks[TimeCompartments.Every2Minutes] = new()
            {
                ScheduleEvery2Minutes1,
                ScheduleEvery2Minutes2,
                ScheduleEvery2Minutes3
            };

            Tasks[TimeCompartments.Every3Minutes] = new()
            {
                ScheduleEvery3Minutes
            };
        }

        public Dictionary<TimeCompartments, List<ScheduledTaskDelegate<object>>> Tasks { get; } = new();

        private Task ScheduleEveryMinute(CancellationToken stoppingToken, object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every minute");
            return Task.CompletedTask;
        }

        private Task ScheduleEvery2Minutes1(CancellationToken stoppingToken, object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every 2 minutes");
            return Task.CompletedTask;
        }

        private Task ScheduleEvery2Minutes2(CancellationToken stoppingToken, object? state)
        {
            throw new Exception("Oh noes!");
        }

        private Task ScheduleEvery2Minutes3(CancellationToken stoppingToken, object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Also every 2 minutes");
            //await _hubContext.Clients.Group(HubConstants.FrontEndPeer).SendAsync("FromSchedule");
            return Task.CompletedTask;
        }

        private Task ScheduleEvery3Minutes(CancellationToken stoppingToken, object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every 3 minutes");
            return Task.CompletedTask;
        }
    }
}
