using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDriverRepository _driverRepository;
        public VehicleService(IVehicleRepository vehicleRepository,IDriverRepository driverRepository)
        {
            _vehicleRepository = vehicleRepository;
            _driverRepository = driverRepository;
        }

        public VehicleDto CreateVehicle(CreateVehicleRequest request)
        {
            Vehicle newVehicle = new Vehicle(request.brand, request.year, request.model);
            _vehicleRepository.Add(newVehicle);
            return VehicleDto.Create(newVehicle);
        }

        public bool DeleteVehicle(int id)
        {
            var vehicleToDelete = _vehicleRepository.GetById(id);
            if (vehicleToDelete != null)
            {
                _vehicleRepository.Delete(vehicleToDelete);
                return true;
            }
            return false;
        }
        
        public VehicleDto GetVehicleById(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            return vehicle != null ? VehicleDto.Create(vehicle) : null; 
        }

        public List<VehicleDto> GetAllVehicles()
        {
            var vehicles = _vehicleRepository.GetAll();
            return vehicles.Select(vehicle => VehicleDto.Create(vehicle)).ToList();
        }

        public VehicleDto UpdateVehicle(VehicleUpdateRequest request,int id)
        {
            Vehicle vehicleToUpdate = _vehicleRepository.GetById(id);
            vehicleToUpdate.Brand = request.brand ?? vehicleToUpdate.Brand;
            vehicleToUpdate.Model = request.model ?? vehicleToUpdate.Model;
            vehicleToUpdate.Year = request.year.HasValue ? request.year.Value : vehicleToUpdate.Year;

            _vehicleRepository.Update(vehicleToUpdate);
            return VehicleDto.Create(vehicleToUpdate);
        }


        public List<DriverDto>? GetAllDrivers(int vehicleId)
        {
            Vehicle vehicle = _vehicleRepository.GetFullVehicleById(vehicleId);
            if (vehicle != null)
            {
                List<Driver> drivers = _vehicleRepository.GetDrivers(vehicle);
                List<DriverDto>? driversMapped = drivers.Select(driver => DriverDto.Create(driver)).ToList();
                return driversMapped;
            }
            return null;
        }

    }
}
