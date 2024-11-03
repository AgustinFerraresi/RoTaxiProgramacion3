using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPassengerRepository : IBaseRepository<Passenger>
    {
        public Passenger? AutenticatePassenger(string email, string password);
    }
}
