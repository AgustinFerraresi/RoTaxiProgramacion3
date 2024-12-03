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
    public interface IVehicleService 
    {
        VehicleDto CreateVehicle(VehicleCreateRequest request, int userId);
        List<VehicleDto> GetAllVehicles();
        VehicleDto GetVehicleById(int id);
        List<DriverDto>? GetVehicleDrivers(int vehicleId);
        VehicleDto? UpdateVehicle(VehicleUpdateRequest request, int id, int userId);
        bool DeleteVehicle(int id, int userId);
    }
}