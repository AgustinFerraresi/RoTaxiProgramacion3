using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDriverService
    {
        void RegisterDriver(Driver driver);
        void DeleteDriver(Driver driver);
        List<Driver> GetAllDrivers();
        public Driver GetDriverById(int id);
    }
}
