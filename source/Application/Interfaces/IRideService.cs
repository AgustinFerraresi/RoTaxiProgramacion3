using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRideService
    {
        RideDto CreateRide(RideCreateRequest request, int userId);
        List<RideDto> GetAllRides();
        RideDto? GetRideById(int id);
        List<RideDto> GetRidesByPassenger(int passengerId);
        void UpdateRide(int id, RideUpdateRequest request, int userId);
        void DeleteRide(int id, int userId);
    }
}
