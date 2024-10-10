using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Classes;
using Domain.Exceptions;
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

        public List<RideDto> GetAll()
        {
            var rides = _rideRepository.GetAll();
            return rides.Select(RideDto.Create).ToList();
        } 

        public RideDto? GetById(int id)
        {
            var ride = _rideRepository.GetById(id);
            return ride != null ? RideDto.Create(ride) : null;
        }

        public RideDto Create(RideCreateRequest request)
        {
            Ride ride = new Ride();
            ride.Date = request.Date;
            ride.Cost = request.Cost;
            ride.PaymentMethod = request.PaymentMethod;

            _rideRepository.Add(ride);
            return RideDto.Create(ride);
        }

        public void Delete(int id)
        {
            var passenger = _rideRepository.GetById(id);
            if (passenger == null)
            {
                throw new NotFoundException("Passenger not found.");
            }
            _rideRepository.Delete(passenger);
        }
    }
}
