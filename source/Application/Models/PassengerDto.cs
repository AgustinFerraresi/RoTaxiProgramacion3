using Domain.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Email { get; set; }
        public string Password { get; set; }
        public int Dni { get; set; }
        public string Description { get; set; }
 

        public static PassengerDto Create(Passenger passenger)
        {
            var dto = new PassengerDto();
            dto.Id = passenger.Id;
            dto.Name = passenger.Name;
            dto.Email = passenger.Email;
            dto.Password = passenger.Password;
            dto.Dni = passenger.Dni;
            dto.Description = passenger.Description;            
      
            return dto;
        }
    }
}