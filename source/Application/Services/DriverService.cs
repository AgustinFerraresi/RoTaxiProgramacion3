using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
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

        public DriverService(IDriverRepository driverRepository,IVehicleRepository vehicleRepository)
        {
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRepository;
        }

        public DriverDto CreateDriver(DriverCreateRequest request)
        {
            Driver newDriver = new Driver(request.Name, request.Email, request.Password, request.Dni);
            _driverRepository.Add(newDriver);
            return DriverDto.Create(newDriver);
        }

        //en cada uno de los metodos se puede usar logica adicional para hacer verificaciones y
        //demas cosas si fuese necesario
        public void DeleteDriver(int id)
        {
            var driver = _driverRepository.GetById(id);
            if (driver == null)
            {
                throw new NotFoundException("Pasajero no encontrado");
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

        public void AddVehicle(int driverId, int vehicleId)
        {
            var driver = _driverRepository.GetFullObjById(driverId);
            var vehicle = _vehicleRepository.GetFullObjById(vehicleId);
            

            if (driver != null && vehicle != null) 
            {
                driver.AddVehicle(vehicle);
            }

            //Driver driver = _vehicleRepository.GetById(driverId);
            //Vehicle vehicle = _vehicleRepository.GetById(vehicleId);
            //driver.Vehicles.Add(vehicle);
            //driver.Vehicles.
            //driver.AddVehicle(vehicle);
        }

    }
}
