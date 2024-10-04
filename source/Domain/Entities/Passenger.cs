using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Passenger : User
    {
        public string Location { get; set; }
        public string Destination { get; set; }
        public List<string> FavsLocations { get; set; }
        public Passenger(string name, string email, string password,int dni , string location, string destination) : base(name, email, password,dni)
        {
            Location = location;
            Destination = destination;
            FavsLocations = new List<string>();
        }
    }
}
