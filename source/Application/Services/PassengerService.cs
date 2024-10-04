using Application.Interfaces;
using Domain.Classes;
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

        public void RegisterPassenger(Passenger passenger) 
        {
            _passengerRepository.Add(passenger);
        }

        public void DeletePassenger(Passenger passenger) 
        {
            _passengerRepository.Delete(passenger);
        }

        public void GetPassengers()
        {
            _passengerRepository.GetAll();
        }
    }
}
