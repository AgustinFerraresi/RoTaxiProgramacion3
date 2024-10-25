using Domain.Classes;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationContext _context;
        public VehicleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Vehicle? GetFullVehicleById(int id)
        {
            //return _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
            return _context.Vehicles.Include(i => i.Drivers).FirstOrDefault(vehicle => vehicle.Id == id);
        }


        public List<Driver> GetDrivers(Vehicle vehicle)
        {
            List<Driver> drivers = vehicle.Drivers;
            return drivers;
        }
    }
}

