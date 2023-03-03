using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.Extensions
{
    public static class SeedingDataExtension
    {
        #region ModelEntityData
        public static EntityTypeBuilder<Model> SeedDataForModel(this EntityTypeBuilder<Model> builder)
        {
            builder.HasData(new List<Model>()
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
            return builder;
        }

        #endregion

        #region StateEntityData
        public static EntityTypeBuilder<State> SeedDataForState(this EntityTypeBuilder<State> builder)
        {
            builder.HasData(new List<State>()
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
                });
            return builder;
        }

        #endregion

        #region DroneEntityData
        public static EntityTypeBuilder<Drone> SeedDataForDrone(this EntityTypeBuilder<Drone> builder)
        {
            //10 drones
            builder.HasData(new List<Drone>()
            {
                new Drone()
                {
                    Id=1,
                    ModelId=(int)DroneModelEnum.HeavyWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=500,


                },
                new Drone()
                {
                    Id=2,
                    ModelId=(int)Domain.Enums.DroneModelEnum.HeavyWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=450,
                },
                 new Drone()
                {
                    Id=3,
                    ModelId=(int)Domain.Enums.DroneModelEnum.HeavyWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=400,
                },
                   new Drone()
                {
                    Id=4,
                    ModelId=(int)Domain.Enums.DroneModelEnum.CruiserWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=375,
                },
                      new Drone()
                {
                    Id=5,
                    ModelId=(int)Domain.Enums.DroneModelEnum.CruiserWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=350,
                },
                         new Drone()
                {
                    Id=6,
                    ModelId=(int)Domain.Enums.DroneModelEnum.MiddleWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=325,
                },
                            new Drone()
                {
                    Id=7,
                    ModelId=(int)Domain.Enums.DroneModelEnum.MiddleWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=300,
                },
                                         new Drone()
                {
                    Id=8,
                    ModelId=(int)Domain.Enums.DroneModelEnum.LightWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=250,
                },
                                                      new Drone()
                {
                    Id=9,
                    ModelId=(int)Domain.Enums.DroneModelEnum.LightWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=200,
                },
                    new Drone()
                    {
                    Id=10,
                    ModelId=(int)Domain.Enums.DroneModelEnum.LightWeight,
                    BatteryCapacity=50,
                    StateId=(int)Domain.Enums.DronesStateEnum.IDLE,
                    Weight=100,
                },
            });
            return builder;
        }

        #endregion


        #region MedicationEntityData
        //public static EntityTypeBuilder<Medication> SeedDataForMedication(this EntityTypeBuilder<Medication> builder)
        //{
        //    builder.HasData(new List<Medication>()
        //    {
        //        new Medication()
        //        {

        //        },
        //        new Medication()
        //        {

        //        },
        //        new Medication()
        //        {

        //        },
        //    });
        //    return builder;
        //}

        #endregion
    }
}
