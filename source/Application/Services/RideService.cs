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
        private readonly IPassengerRepository _passengerRepository;

        public RideService(IRideRepository rideRepository, IPassengerRepository passengerRepository)
        {
            _rideRepository = rideRepository;
            _passengerRepository = passengerRepository;
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

        public RideDto Create(RideCreateRequest request, int userId)
        {
            var authenticatedPassenger = _passengerRepository.GetById(userId);

            Ride ride = new Ride();
            ride.Location = request.Location;
            ride.Destination = request.Destination;
            ride.Date = request.Date;
            ride.Cost = request.Cost;
            ride.PaymentMethod = request.PaymentMethod;

            _rideRepository.Add(ride);
            return RideDto.Create(ride);
        }

        public void Delete(int id)
        {
            var ride = _rideRepository.GetById(id);
            if (ride == null)
            {
                throw new NotFoundException("Viaje not found.");
            }
            _rideRepository.Delete(ride);
        }

        public void Update(int id, RideUpdateRequest request)
        {
            var ride = _rideRepository.GetById(id) ?? throw new NotFoundException($"Viaje {id} no encontrado.");

            ride.Location = request.Location ?? ride.Location;
            ride.Destination = request.Destination ?? ride.Destination;
            ride.Date = request.Date ?? ride.Date;
            ride.Cost = request.Cost ?? ride.Cost;
            ride.PaymentMethod = request.PaymentMethod ?? ride.PaymentMethod;

            _rideRepository.Update(ride);
        }
    }
}
