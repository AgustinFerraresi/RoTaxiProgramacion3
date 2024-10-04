using Application.Interfaces;
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

        //en cada uno de los metodos se puede usar logica adicional para hacer verificaciones y demas cosas si fuese necesario
        public void DeleteDriver(Driver driver)
        {
            _driverRepository.Delete(driver);
        }

        public List<Driver> GetAllDrivers()
        {
            return _driverRepository.GetAll();
        }

        public void RegisterDriver(Driver driver)
        {
            _driverRepository.Add(driver);
        }

        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetById(id);
        }

    }
}
