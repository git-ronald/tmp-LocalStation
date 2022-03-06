using CoreLibrary;
using CoreLibrary.Helpers;
using PeerLibrary.Scheduler;

namespace TestAppLibrary.Scheduler
{
    internal class TimeCompartmentSchedulerConfig : PeerCompartmentSchedulerConfig //ISchedulerConfig<object, TimeCompartments>
    {
        public TimeCompartmentSchedulerConfig()
        {
            //Tasks[TimeCompartments.Every2Minutes] = new()
            //{
            //    ScheduleEvery2Minutes1,
            //    ScheduleEvery2Minutes2,
            //};

            //Tasks[TimeCompartments.Every3Minutes] = new()
            //{
            //    ScheduleEvery3Minutes
            //};

            Tasks.Ensure(TimeCompartments.Every2Minutes).AddItems(
                ScheduleEvery2Minutes1,
                ScheduleEvery2Minutes2);

            Tasks.Ensure(TimeCompartments.Every3Minutes).AddItems(
                ScheduleEvery3Minutes);
        }

        private Task ScheduleEvery2Minutes1(CancellationToken stoppingToken, object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every 2 minutes by TestApp");
            return Task.CompletedTask;
        }

        private Task ScheduleEvery2Minutes2(CancellationToken stoppingToken, object? state)
        {
            throw new Exception("Oh noes!");
        }

        private Task ScheduleEvery3Minutes(CancellationToken stoppingToken, object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} Every 3 minutes by TestApp");
            return Task.CompletedTask;
        }
    }
}
