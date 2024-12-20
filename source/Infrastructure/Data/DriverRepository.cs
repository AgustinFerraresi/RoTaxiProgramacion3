﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        private readonly ApplicationContext _context;
        public DriverRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Driver? GetById(int id)
        {
            return _context.Drivers.FirstOrDefault(driver => driver.Id == id);
        }
 
        public Driver? GetFullDriverById(int id)
        {
            return _context.Drivers.Include(i => i._vehicles).FirstOrDefault(driver => driver.Id == id);
        }

        public List<Vehicle> GetDriverVehicles(Driver driver)
        {
            List<Vehicle> vehicles = driver._vehicles;
            return vehicles;
        }

        public void AddDriverToVehicle(Driver driver, Vehicle vehicle)
        {
            driver._vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void DeleteVehicle(Driver driver, Vehicle vehicle)
        {
            driver._vehicles.Remove(vehicle);
            _context.SaveChanges();
        }

        public Driver? AutenticarDriver(string email, string password)
        {
            return _context.Drivers.SingleOrDefault(d => d.Email == email && d.Password == password);

        }

        public void TakeRide(Driver driver)
        {
            driver.Available = false;
            _context.SaveChanges();
        }

        public void FinishRide(Driver driver)
        {
            driver.Available = true;
            _context.SaveChanges();
        }
    }
}
