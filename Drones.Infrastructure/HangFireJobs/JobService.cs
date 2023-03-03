using Drones.Domain.Interfaces.Services;
using Drones.Domain.Services;
using Hangfire;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.HangFireJobs
{
    public class JobService : IJobService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ILogger<JobService> _logger;
        private readonly IDroneService _droneService;
        public JobService(IRecurringJobManager recurringJobManager, ILogger<JobService> logger, IDroneService droneService)
        {
            _recurringJobManager = recurringJobManager;
            _logger = logger;
            _droneService = droneService;

        }

        public async Task LogForDroneBatteries()
        {
            var drones = await _droneService.GetAllDrones();
            foreach (var item in drones)
            {
                _logger.LogInformation($"Message: Drone With SerialNumber: {item.SerialNumber}, Battery: {item.BatteryCapacity}%, Time: {DateTime.Now}");
            }
        }
        public void AddJobForDroneBatteries()
        {

            _recurringJobManager.AddOrUpdate("DroneBatteryJob", () => LogForDroneBatteries(), Cron.Minutely);

        }

        public void Dispose()
        {

        }
    }
}
