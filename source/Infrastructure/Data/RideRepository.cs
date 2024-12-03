using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RideRepository : BaseRepository<Ride> , IRideRepository
    {
        private readonly ApplicationContext _context;

        public RideRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override List<Ride> GetAll()
        {
            return _context.Rides
                    .Include(r => r.Passenger)
                    .ToList();
        }

        public override Ride? GetById<TId>(TId id)
        {
            if (id is int intId)
            {
                return _context.Rides
                               .Include(r => r.Passenger)
                               .FirstOrDefault(r => r.Id == intId);
            }
            throw new ArgumentException("Tipo de ID no compatible.");
        }
    }
}
