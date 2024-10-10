using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PassengerDto
    {
        //aca van todos las props de passenger que voy a querer mostrar
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dni { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }

        public static PassengerDto Create(Passenger passenger)
        {
            var dto = new PassengerDto();
            dto.Id = passenger.Id;
            dto.Name = passenger.Name;
            dto.Dni = passenger.Dni;
            dto.Location = passenger.Location;
            dto.Destination = passenger.Destination;

            return dto;
        }
    }
}