using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Driver : User
    {
        public bool Available { get; set; }
        public List<Vehicle> _vehicles { get; set; }
        public Driver(string name, string email, string password, int dni) : base(name, email, password, dni)
        {
            Available = false;
            _vehicles = new List<Vehicle>();
        }
    }
}