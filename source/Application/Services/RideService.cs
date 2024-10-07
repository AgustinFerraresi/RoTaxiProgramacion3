using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RideService : IRideService
    {
        private readonly IRideRepository _rideRepository;

        public RideService(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        public RideDto CreateRide(RideRequest request)
        {
            var newRide = new Ride(request.Cost, request.PaymentMethod);
            _rideRepository.Add(newRide);
            return RideDto.Create(newRide);
        }
        public void CanceleRide(Ride ride)
        {
            throw new NotImplementedException();
        }

        public List<Ride> GetAllRides()
        {
            throw new NotImplementedException();
        }
    }
}
