using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Passenger : User
    {
        [Required]
        public string Location { get; set; }

        [Required]
        public string Destination { get; set; }

        public Passenger(string name, string email, string password,int dni , string location, string destination) : base(name, email, password,dni)
        {
            Location = location;
            Destination = destination;
        }
    }
}
