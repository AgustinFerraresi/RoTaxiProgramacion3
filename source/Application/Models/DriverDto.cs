using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DriverDto
    {
        public string Name { get; set; }
        public int Dni { get; set; }
        public bool Available { get; set; } 


        public static DriverDto Create(Driver driver)
        {
            var dto = new DriverDto();

            dto.Name = driver.Name;
            dto.Dni = driver.Dni;
            dto.Available = driver.Available;

            return dto;
        }
    }
}
