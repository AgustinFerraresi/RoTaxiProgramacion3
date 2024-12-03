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
    public interface IDriverService
    {
        DriverDto CreateDriver(DriverCreateRequest request);
        List<DriverDto> GetAllDrivers();
        DriverDto? GetDriverById(int id);
        void UpdateDriver(int id, DriverUpdateRequest request, int userId);
        void DeleteDriver(int id, int userId);
        List<VehicleDto>? GetAllDriverVehicles(int driverId);
        bool AddDriverToVehicle(int driverId, int vehicleId, int userId);
        bool DeleteDriverToVehicle(int driverId, int vehicleId, int userId);
        bool TakeRide(int driverId, int rideId, int userId);
        bool FinishRide(int driverId, int userId);
    }
}
