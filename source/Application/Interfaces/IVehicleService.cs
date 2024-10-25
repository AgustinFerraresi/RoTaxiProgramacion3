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
    public interface IVehicleService 
    {
        VehicleDto CreateVehicle(CreateVehicleRequest request, int userId);
     
        List<VehicleDto> GetAllVehicles();
        VehicleDto GetVehicleById(int id);
        
        //Vehicle GetFullVehicleById(int id);
        List<DriverDto>? GetAllDrivers(int vehicleId);
        VehicleDto? UpdateVehicle(VehicleUpdateRequest request, int id, int userId);
        bool DeleteVehicle(int id, int userId);
    }
}