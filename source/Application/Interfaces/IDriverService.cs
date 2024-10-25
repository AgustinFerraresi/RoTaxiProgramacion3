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
        void DeleteDriver(int id, int userId);
        void UpdateDriver(int id, DriverUpdateRequest request, int userId);
        List<DriverDto> GetAllDrivers();
        DriverDto? GetDriverById(int id);
        bool AddVehicle(int driverId, int vehicleId, int userId);
        List<VehicleDto>? GetAllDriverVehicles(int driverId);
        bool DeleteDriverVehicle(int driverId, int vehicleId, int userId);
        // SACAR EL COMENTADO DESPUES EL METODO EL METODO SIRVE
        //bool AcceptDrive(int driverId, int rideId);
    }
}
