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
        VehicleDto CreateVehicle(CreateVehicleRequest request);
        bool DeleteVehicle(int id);
        List<VehicleDto> GetAllVehicles();
        VehicleDto GetVehicleById(int id);
        VehicleDto UpdateVehicle(VehicleUpdateRequest request, int id);
    }
}