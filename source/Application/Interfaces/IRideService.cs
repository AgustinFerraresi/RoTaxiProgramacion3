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
    public interface IRideService
    {
        public RideDto CreateRide(RideRequest request);

        public void CanceleRide(Ride ride); //no estoy seguro si este metodo esta bien

        public List<Ride> GetAllRides();
    }
}
