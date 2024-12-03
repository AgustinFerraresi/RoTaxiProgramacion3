using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Dni { get; set; }
        public bool Available { get; set; } 


        public static DriverDto Create(Driver driver)
        {
            var dto = new DriverDto();
            dto.Id = driver.Id;
            dto.Name = driver.Name;
            dto.Email = driver.Email;
            dto.Password = driver.Password;
            dto.Dni = driver.Dni;
            dto.Available = driver.Available;

            return dto;
        }
    }
}
