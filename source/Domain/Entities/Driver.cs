using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    //tengo que ver como guardar los autos pertenecientes a cada driver, guardarlos en una lista dentro de Driver no es una buena opcion
    
    public class Driver : User
    {
        public bool Available { get; set; }
        public Driver(string name, string email, string password, int dni) : base(name, email, password, dni)
        {
            Available = false;
        }
    }
}