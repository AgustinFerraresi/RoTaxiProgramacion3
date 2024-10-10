using Domain.Classes;
using Domain.Interfaces;
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

    }
}
