using Drones.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.Extensions
{
    public static class AddJobExtension
    {
        public static IHost AddDroneJobs(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var jobService = scope.ServiceProvider.GetRequiredService<IJobService>())
                {
                    jobService.AddJobForDroneBatteries();
                }
            }
            return host;
        }
    }
}
