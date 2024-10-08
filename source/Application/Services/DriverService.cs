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
    public class DriverService : IDriverService 
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDto CreateDriver(DriverRequest request)
        {
            Driver newDriver = new Driver(request.Name, request.Email, request.Password, request.Dni);
            _driverRepository.Add(newDriver);
            return DriverDto.Create(newDriver);
        }

        //en cada uno de los metodos se puede usar logica adicional para hacer verificaciones y demas cosas si fuese necesario
        public void DeleteDriver(Driver driver)
        {
            _driverRepository.Delete(driver);
        }

        public List<Driver> GetAllDrivers()
        {
            return _driverRepository.GetAll();
        }

        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetById(id);
        }

    }
}
