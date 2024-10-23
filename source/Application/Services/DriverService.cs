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

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDto CreateDriver(DriverCreateRequest request)
        {
            Driver newDriver = new Driver(request.Name, request.Email, request.Password, request.Dni);
            _driverRepository.Add(newDriver);
            return DriverDto.Create(newDriver);
        }

        //en cada uno de los metodos se puede usar logica adicional para hacer verificaciones y demas cosas si fuese necesario
        public void DeleteDriver(int id, int userId)
        {
            var driver = _driverRepository.GetById(id) ?? throw new NotFoundException($"Conductor {id} no encontrado."); ;
            if (driver.Id != userId) throw new NotAllowedException("Acceso denegado.");
            _driverRepository.Delete(driver);
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

    }
}
