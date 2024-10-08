using Application.Interfaces;
using Application.Request;
using Application.Response;
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
        //aca lo que hago es pasarle una entidad que implemente la interfaz "IPassengerRepository" dicha entidad esta especificada
        //en program en esta linea builder.Services.AddSingleton<IPassengerRepository, PassengerRepository>();
        private readonly IPassengerRepository _passengerRepository;

        //aca inyecto el repo y hago metodos que llaman a los metodos del repo que llaman a metodos del baseRepo
        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public PassengerDto CreatePassenger(PassengerRequest request)
        {
            Passenger newPassenger = new Passenger(request.Name, request.Email, request.Password, request.Dni, request.Location, request.Destination);
            _passengerRepository.Add(newPassenger);
            return PassengerDto.Create(newPassenger);
        }

        public void DeletePassenger(int id)
        {
            var passenger = _passengerRepository.GetById(id);
            if (passenger == null)
            {
                throw new NotFoundException("Passenger not found.");
            }
            _passengerRepository.Delete(passenger);
        }

        public List<PassengerDto> GetAllPassenger()
        {
            var passengers = _passengerRepository.GetAll();
            return passengers.Select(PassengerDto.Create).ToList();
        }

        public PassengerDto? GetPassengerById(int id)
        {
            var passenger = _passengerRepository.GetById(id);
            return passenger != null ? PassengerDto.Create(passenger) : null;
        }
    }
}
