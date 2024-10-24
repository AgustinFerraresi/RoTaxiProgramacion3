﻿using Application.Interfaces;
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
    public class PassengerService : IPassangerService
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public PassengerDto Create(PassengerCreateRequest request)
        {
            Passenger passenger = new Passenger(request.Name, request.Email, request.Password, request.Dni);

            _passengerRepository.Add(passenger);
            return PassengerDto.Create(passenger);
        }

        public void Delete(int id, int userId)
        {
            var passenger = _passengerRepository.GetById(id) ?? throw new NotFoundException($"Pasajero {id} no encontrado."); ;
            if (passenger.Id != userId) throw new NotAllowedException("Acceso denegado.");
            _passengerRepository.Delete(passenger);
        }

        public List<PassengerDto> GetAll()
        {
            var passengers = _passengerRepository.GetAll();
            return passengers.Select(PassengerDto.Create).ToList();
        }

        public PassengerDto? GetById(int id)
        {
            var passenger = _passengerRepository.GetById(id);
            return passenger != null ? PassengerDto.Create(passenger) : null;
        }

        public void Update(int id, PassengerUpdateRequest request, int userId)
        {
            var passenger = _passengerRepository.GetById(id) ?? throw new NotFoundException($"Pasajero {id} no encontrado.");
            if (passenger.Id != userId) throw new NotAllowedException("Acceso denegado.");

            passenger.Name = request.Name ?? passenger.Name;
            passenger.Email = request.Email ?? passenger.Email;
            passenger.Password = request.Password ?? passenger.Password;
            passenger.Dni = request.Dni ?? passenger.Dni;
            passenger.Description = request.Description ?? passenger.Description;

            _passengerRepository.Update(passenger);
        }
    }
}
