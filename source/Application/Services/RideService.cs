﻿using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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


        public RideDto CreateRide(RideCreateRequest request, int userId)
        {
            var authenticatedPassenger = _passengerRepository.GetById(userId);

            Ride ride = new Ride();
            ride.Passenger = authenticatedPassenger;
            ride.Location = request.Location;
            ride.Destination = request.Destination;
            ride.Date = request.Date;
            ride.Cost = request.Cost;
            ride.PaymentMethod = request.PaymentMethod;
            ride.Message = request.Message;

            _rideRepository.Add(ride);
            return RideDto.Create(ride);
        }


        public List<RideDto> GetAllRides()
        {
            var rides = _rideRepository.GetAll();
            return rides.Select(RideDto.Create).ToList();
        } 


        public RideDto? GetRideById(int id)
        {
            var ride = _rideRepository.GetById(id) ?? throw new NotFoundException($"Viaje {id} no encontrado");
            return RideDto.Create(ride);
        }


        public List<RideDto> GetRidesByPassenger(int passengerId)
        {
            var passenger = _passengerRepository.GetById(passengerId) ?? throw new NotFoundException($"Pasajero no encontrado");
            var rides = _rideRepository.GetAll().Where(rides => rides.Passenger.Id == passengerId).ToList();
            return rides.Select(RideDto.Create).ToList();
        }


        public void UpdateRide(int id, RideUpdateRequest request, int userId)
        {
            Passenger authenticatedPassenger = _passengerRepository.GetById(userId);

            var ride = _rideRepository.GetById(id) ?? throw new NotFoundException("Viaje no encontrado");
            if (ride.Passenger.Id != authenticatedPassenger.Id) throw new NotAllowedException("Acceso denegado.");

            ride.Location = request.Location ?? ride.Location;
            ride.Destination = request.Destination ?? ride.Destination;
            ride.Date = request.Date ?? ride.Date;
            ride.Cost = request.Cost ?? ride.Cost;
            ride.PaymentMethod = request.PaymentMethod ?? ride.PaymentMethod;
            ride.Message = request.Message ?? ride.Message;

            _rideRepository.Update(ride);
        }


        public void DeleteRide(int id, int userId)
        {
            Passenger authenticatedPassenger = _passengerRepository.GetById(userId);

            var ride = _rideRepository.GetById(id) ?? throw new NotFoundException($"Viaje {id} no encontrado");
            if (ride.Passenger.Id != authenticatedPassenger.Id) throw new NotAllowedException("Acceso denegado.");
            _rideRepository.Delete(ride);
        }
    }
}
