using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class PassengerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Dni { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
    }
}


//public Passenger(string name, string email, string password, int dni, string location, string destination) : base(name, email, password, dni)
//        {
//    Location = location;
//    Destination = destination;
//}