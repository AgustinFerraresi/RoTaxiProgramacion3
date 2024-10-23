using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
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
        private readonly IRideRepository _rideRepository
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


        public void DeleteDriver(int id)
        {
            var driver = _driverRepository.GetById(id);
            if (driver == null)
            {
                throw new NotFoundException("Conductor no encontrado.");
            }
            _driverRepository.Delete(driver);
        }


        public void UpdateDriver(int id, DriverUpdateRequest request)
        {
            var driver = _driverRepository.GetById(id) ?? throw new NotFoundException($"Pasajero {id} no encontrado.");

            driver.Name = request.Name ?? driver.Name;
            driver.Email = request.Email ?? driver.Email;
            driver.Password = request.Password ?? driver.Password;
            driver.Dni = request.Dni ?? driver.Dni;


            _driverRepository.Update(driver);
        }


        public List<DriverDto> GetAllDrivers()
        {
            var driver = _driverRepository.GetAll();
            return driver.Select(DriverDto.Create).ToList();
        }


        public DriverDto? GetDriverById(int id)
        {
            var driver = _driverRepository.GetById(id);
            return driver != null ? DriverDto.Create(driver) : null;
        }


        public bool AddVehicle(int driverId, int vehicleId)
        {
            Driver driver = _driverRepository.GetFullDriverById(driverId);
            Vehicle vehicle = _vehicleRepository.GetFullVehicleById(vehicleId);

            if (driver != null && vehicle != null && !(driver._vehicles.Contains(vehicle)))
            {
                _driverRepository.AddVehicle(driver, vehicle); //agrego un vehiculo a un conductor
                return true;
            }
            return false;
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


        public bool DeleteDriverVehicle(int driverId, int vehicleId)
        {
            Driver driver = _driverRepository.GetFullDriverById(driverId);
            Vehicle vehicle = _vehicleRepository.GetFullVehicleById(vehicleId);

            if (driver != null && vehicle != null && driver._vehicles.Contains(vehicle))
            {
                _driverRepository.DeleteVehicle(driver,vehicle);//elimino un vehiculo de un conductor
                //_vehicleRepository.DeleteDriverFromVehicle(vehicle, driver);//elimino un conductor de un vehiculo
                return true;
            }
            return false;
        }

        // SACAR EL COMENTADO DESPUES EL METODO EL METODO SIRVE
        //public bool AcceptDrive(int driverId,int rideId)
        //{
        //    var ride = _rideRepository.GetById(rideId);
        //    var driver = _driverRepository.GetById(driverId);
        //    if (driver == null || ride == null || driver.Available == false)
        //    {
        //        return false;
        //    }
        //    driver.Available = false;
        //    return true;
        //}
    }
}
