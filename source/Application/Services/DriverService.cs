using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRideRepository _rideRepository;
        public DriverService(IDriverRepository driverRepository, IVehicleRepository vehicleRepository,IRideRepository rideRepository)
        {
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRepository;
            _rideRepository = rideRepository;
        }

        public DriverDto CreateDriver(DriverCreateRequest request)
        {
            Driver newDriver = new Driver(request.Name, request.Email, request.Password, request.Dni);
            _driverRepository.Add(newDriver);
            return DriverDto.Create(newDriver);
        }


        public List<DriverDto> GetAllDrivers()
        {
            var driver = _driverRepository.GetAll();
            return driver.Select(DriverDto.Create).ToList();
        }


        public DriverDto? GetDriverById(int id)
        {
            var driver = _driverRepository.GetById(id) ?? throw new NotFoundException($"Conductor {id} no encontrado");
            return DriverDto.Create(driver);
        }


        public void UpdateDriver(int id, DriverUpdateRequest request, int userId)
        {
            var driver = _driverRepository.GetById(id) ?? throw new NotFoundException($"Conductor {id} no encontrado.");
            if (driver.Id != userId) throw new NotAllowedException("Acceso denegado.");

            driver.Name = request.Name ?? driver.Name;
            driver.Email = request.Email ?? driver.Email;
            driver.Password = request.Password ?? driver.Password;
            driver.Dni = request.Dni ?? driver.Dni;


            _driverRepository.Update(driver);
        }

        public void DeleteDriver(int id, int userId)
        {
            var driver = _driverRepository.GetById(id) ?? throw new NotFoundException($"Conductor {id} no encontrado."); ;
            if (driver.Id != userId) throw new NotAllowedException("Acceso denegado.");
            _driverRepository.Delete(driver);
        }


        public List<VehicleDto>? GetAllDriverVehicles(int driverId)
        {
            Driver driver = _driverRepository.GetFullDriverById(driverId);
            if (driver == null)
            {
                return null;
            }

            List<Vehicle> driverVehicles = _driverRepository.GetDriverVehicles(driver);
            List<VehicleDto> driverVehiclesMapped = driverVehicles
                .Select(vehicle => VehicleDto.Create(vehicle))
                .ToList();

            return driverVehiclesMapped;
        }

        public bool AddDriverToVehicle(int driverId, int vehicleId, int userId)
        {
            Driver driver = _driverRepository.GetById(driverId) ?? throw new NotFoundException($"Conductor no encontrado.");
            if (driver.Id != userId) throw new NotAllowedException("Acceso denegado.");

            Vehicle vehicle = _vehicleRepository.GetFullVehicleById(vehicleId) ?? throw new NotFoundException($"Vehículo {vehicleId} no encontrado.");

            if (!driver._vehicles.Contains(vehicle))
            {
                _driverRepository.AddDriverToVehicle(driver, vehicle); //agrego un vehiculo a un conductor
                return true;
            }
            return false;
        }


        public bool DeleteDriverToVehicle(int driverId, int vehicleId, int userId)
        {
            Driver driver = _driverRepository.GetFullDriverById(driverId);
            Vehicle vehicle = _vehicleRepository.GetFullVehicleById(vehicleId);

            if (driver == null) throw new NotFoundException($"Conductor {driverId} no encontrado.");
            if (vehicle == null) throw new NotFoundException($"Vehículo {vehicleId} no encontrado.");

            if (driver.Id != userId)
            {
                throw new UnauthorizedAccessException("Acceso denegado");
            }

            if (driver._vehicles.Contains(vehicle))
            {
                _driverRepository.DeleteVehicle(driver,vehicle);//elimino un vehiculo de un conductor
                return true;
            }
            return false;
        }


        public bool TakeRide(int driverId, int rideId, int userId)
        {
            var ride = _rideRepository.GetById(rideId);
            Driver? driver = _driverRepository.GetFullDriverById(driverId);

            if (driver == null || ride == null || driver.Available == false)
            {
                return false;
            }
            if (driver.Id != userId) return false;

            _driverRepository.TakeRide(driver);
            return true;
        }


        public bool FinishRide(int driverId, int userId)
        {
            Driver? driver = _driverRepository.GetFullDriverById(driverId);
            if (driver.Id != userId) return false;

            if (driver == null || driver.Available == true)
            {
                return false;
            }
            _driverRepository.FinishRide(driver);
            return true;
        }
    }
}
