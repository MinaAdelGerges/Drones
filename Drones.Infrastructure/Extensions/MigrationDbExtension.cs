using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drones.Infrastructure.Extensions
{
    public static class MigrationExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {



            var options = new DbContextOptionsBuilder<DronesDbContext>().UseInMemoryDatabase(databaseName: "database_name").Options;

            using (var context = new DronesDbContext(options))
            {

            }

            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DronesDbContext>())
                {
                    //states
                    #region SeedDataForStates

                    appContext.States.AddRange(

                    #endregion
                    new List<State>
                    {
                        new State()
                {
                    Id=(int)DronesStateEnum.IDLE,
                    Name=DronesStateEnum.IDLE.ToString()
                },
                new State()
                {
                    Id=(int)DronesStateEnum.LOADING,
                    Name=DronesStateEnum.LOADING.ToString()
                },
                 new State()
                {
                    Id = (int)DronesStateEnum.LOADED,
                    Name=DronesStateEnum.LOADED.ToString()
                },
                   new State()
                {
                    Id = (int)DronesStateEnum.DELIVERING,
                    Name=DronesStateEnum.DELIVERING.ToString()
                },
                      new State()
                {
                    Id = (int)DronesStateEnum.DELIVERED,
                    Name=DronesStateEnum.DELIVERED.ToString()
                },
                             new State()
                {
                    Id = (int)DronesStateEnum.RETURNING,
                    Name=DronesStateEnum.RETURNING.ToString()
                },
                    }
                    );

                    #region SeedDataForModels
                    appContext.Models.AddRange(new List<Model>()
            {
                new Model()
                {
                    Id=(int)DroneModelEnum.LightWeight,
                    Name=DroneModelEnum.LightWeight.ToString()
                },
                new Model()
                {
                    Id=(int)DroneModelEnum.MiddleWeight,
                    Name=DroneModelEnum.MiddleWeight.ToString()
                },
                new Model()
                {
                    Id=(int)DroneModelEnum.CruiserWeight,
                    Name=DroneModelEnum.CruiserWeight.ToString()
                },
                  new Model()
                {
                    Id=(int)DroneModelEnum.HeavyWeight,
                    Name=DroneModelEnum.HeavyWeight.ToString()
                },
            });
                    #endregion



                    #region SeedDataForDrones
                    appContext.Drones.AddRange(new List<Drone>()
            {
                new Drone()
                {
                    Id=1,
                    SerialNumber=1,
                    ModelId=(int)DroneModelEnum.HeavyWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.LOADED,
                    Weight=500,


                },
                new Drone()
                {
                    Id=2,
                      SerialNumber=2,
                    ModelId=(int)Domain.Enums.DroneModelEnum.HeavyWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.LOADED,
                    Weight=450,
                },
                 new Drone()
                {
                    Id=3,
                      SerialNumber=3,

                    ModelId=(int)Domain.Enums.DroneModelEnum.HeavyWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.LOADED,
                    Weight=400,
                },
                   new Drone()
                {
                    Id=4,
                      SerialNumber=4,

                    ModelId=(int)Domain.Enums.DroneModelEnum.CruiserWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.LOADED,
                    Weight=375,
                },
                      new Drone()
                {
                    Id=5,
                                          SerialNumber=5,

                    ModelId=(int)Domain.Enums.DroneModelEnum.CruiserWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=350,
                },
                         new Drone()
                {
                    Id=6,
                                                              SerialNumber=6,

                    ModelId=(int)Domain.Enums.DroneModelEnum.MiddleWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=325,
                },
                            new Drone()
                {
                    Id=7,
                                                                                  SerialNumber=7,

                    ModelId=(int)Domain.Enums.DroneModelEnum.MiddleWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=300,
                },
                                         new Drone()
                {
                    Id=8,
                                                                                  SerialNumber=8,

                    ModelId=(int)Domain.Enums.DroneModelEnum.LightWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=250,
                },
                                                      new Drone()
                {
                    Id=9,
                                                                                  SerialNumber=9,

                    ModelId=(int)Domain.Enums.DroneModelEnum.LightWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=200,
                },
                    new Drone()
                    {
                    Id=10,
                                                                                  SerialNumber=10,

                    ModelId=(int)Domain.Enums.DroneModelEnum.LightWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=100,
                },
            });
                    #endregion

                    #region SeedDataForMedications
                    appContext.Medications.AddRange(new List<Medication>()
            {
                new Medication()
                {
                    Id=1,
                    Code="Med1",
                    Name="Medication1",
                    Weight=390,
                               DroneId=4
                               ,
                                           Image="image1"

                },
                new Medication()
                  {
                    Id=2,
                            Code="Med2",
                    Name="Medication2",
                    Weight=320,
                               DroneId=3,
                                           Image="image2"

                },
                 new Medication()
                  {
                    Id=3,
                            Code="Med3",
                    Name="Medication3",
                    Weight=375,

                       DroneId=2,
                                           Image="image3"

                },
                   new Medication()
                  {
                    Id=4,
                            Code="Med4",
                    Name="Medication4",
                    Weight=350,
                    DroneId=1,
                    Image="image4"


                },
                      new Medication()
                  {
                    Id=5,
                            Code="Med5",
                    Name="Medication5",
                    Weight=350,
                    Image="image5"


                },
                         new Medication()
                  {
                    Id=6,
                            Code="Med6",
                    Name="Medication6",
                    Weight=350,
                    Image="image6"


                },
                            new Medication()
                  {
                    Id=4,
                            Code="Med7",
                    Name="Medication7",
                    Weight=350,
                    Image="image7"


                },
                               new Medication()
                  {
                    Id=8,
                            Code="Med8",
                    Name="Medication8",
                    Weight=350,
                    Image="image48"


                },
            });
                    #endregion
                    appContext.SaveChanges();






                    //appContext.Database.Migrate();
                }
            }
            return host;
        }
    }
}
