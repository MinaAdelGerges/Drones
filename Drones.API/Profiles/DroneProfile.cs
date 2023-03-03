using AutoMapper;
using Drones.Domain.Dtos;
using Drones.Domain.Entities;

namespace Drones.API.Profiles
{
    public class DroneProfile : Profile
    {
        public DroneProfile()
        {
            CreateMap<Drone, DroneDto>();

        }
    }
}
