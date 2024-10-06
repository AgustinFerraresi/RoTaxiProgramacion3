using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class DriverDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public int Dni { get; set; }

        public static DriverDto Create(Driver driver)
        {
            var dto = new DriverDto();

            dto.Name = driver.Name;
            dto.Email = driver.Email;
            dto.Id = driver.Id;
            dto.Dni = driver.Dni;

            return dto;
        }
    }
}
