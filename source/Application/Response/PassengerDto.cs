using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class PassengerDto
    {
        //aca van todos las props de passenger que voy a querer mostrar
        public string Name { get; set; }
        public int Dni { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }

        public static PassengerDto Create(Passenger passenger)
        {
            var dto = new PassengerDto();

            dto.Name = passenger.Name;
            dto.Dni = passenger.Dni;
            dto.Location = passenger.Location;
            dto.Destination = passenger.Destination;

            return dto;
        }
    }
}
//public Passenger(string name, string email, string password, int dni, string location, string destination) : base(name, email, password, dni)
//{
//    Location = location;
//    Destination = destination;
//}