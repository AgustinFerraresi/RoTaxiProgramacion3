using Domain.Entities;
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
        List<Vehicle> GetDriverVehicles(Driver driver);
        void AddDriverToVehicle(Driver driver, Vehicle vehicle);
        void DeleteVehicle(Driver driver, Vehicle vehicle);
        void TakeRide(Driver driver);
        void FinishRide(Driver driver);        
        public Driver? AutenticarDriver(string email, string password);
    }
}
