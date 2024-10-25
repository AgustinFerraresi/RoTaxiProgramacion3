using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        Driver?  GetById(int id);
        Driver? GetFullDriverById(int id);
        void AddVehicle(Driver driver, Vehicle vehicle);
        List<Vehicle> GetDriverVehicles(Driver driver);
        void DeleteVehicle(Driver driver, Vehicle vehicle);
        void EndRide(Driver driver);
        void AcceptRide(Driver driver);
        public Driver? AutenticarDriver(string email, string password);
    }
}
