using Application.Request;
using Application.Response;
using Domain.Classes;
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
        void DeleteVehicle(Vehicle vehicle);
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicleById(int id);
    }
}