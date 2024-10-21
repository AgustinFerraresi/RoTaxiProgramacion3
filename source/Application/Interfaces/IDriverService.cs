using Application.Models;
using Application.Models.Request;
using Domain.Classes;
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
        void DeleteDriver(int id);
        void UpdateDriver(int id, DriverUpdateRequest request);
        List<DriverDto> GetAllDrivers();
        DriverDto? GetDriverById(int id);
        bool AddVehicle(int driverId, int vehicleId);
        List<VehicleDto> GetAllDriverVehicles(int driverId);
        bool DeleteDriverVehicle(int driverId, int vehicleId);
    }
}
