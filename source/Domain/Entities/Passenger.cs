using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger : User
    {
        public string? Description { get; set; }

        public Passenger(string name, string email, string password, int dni) : base(name, email, password, dni)
        {
        }
    }
}
