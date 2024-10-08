using Application.Request;
using Application.Response;
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

        DriverDto CreateDriver(DriverRequest request);
        void DeleteDriver(int id);
        List<Driver> GetAllDrivers();
        public Driver GetDriverById(int id);
    }
}
