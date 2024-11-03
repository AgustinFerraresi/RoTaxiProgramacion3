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
        public string Name { get; set; }
        public int Dni { get; set; }
        public string Description { get; set; }
 

        public static PassengerDto Create(Passenger passenger)
        {
            var dto = new PassengerDto();
            dto.Name = passenger.Name;
            dto.Dni = passenger.Dni;
            dto.Description = passenger.Description;            
      
            return dto;
        }
    }
}