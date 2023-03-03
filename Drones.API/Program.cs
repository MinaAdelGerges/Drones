using Drones.Domain.Enums;
using Drones.Domain.Interfaces.Repositories;
using Drones.Domain.Interfaces.Services;
using Drones.Domain.Services;
using Drones.Infrastructure.Data;
using Drones.Infrastructure.Extensions;
using Drones.Infrastructure.HangFireJobs;
using Drones.Infrastructure.Repositories;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Drones.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddScoped<DbContext, DronesDbContext>();
            builder.Services.AddDbContext<DronesDbContext>(opt => opt.UseInMemoryDatabase("DroneDb"));
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            builder.Services.AddHangfire(c => c.UseMemoryStorage());

            builder.Services.AddLogging();
            builder.Services.AddScoped<IDroneService, DronService>();
            builder.Services.AddScoped<IMedicationService, MedicationService>();

            builder.Services.AddTransient<IJobService, JobService>();

            var app = builder.Build();
            //migrate our db
            app.MigrateDatabase();
            //add Drone Jobs
            app.AddDroneJobs();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}