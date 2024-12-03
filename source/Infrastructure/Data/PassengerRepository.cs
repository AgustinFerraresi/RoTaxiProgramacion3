using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Numerics;

namespace Infrastructure.Data   
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        private readonly ApplicationContext _context;
        public PassengerRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Passenger? AutenticatePassenger(string email, string password)
        {
            return _context.Passengers.SingleOrDefault(p => p.Email == email && p.Password == password);
        }
    }
}