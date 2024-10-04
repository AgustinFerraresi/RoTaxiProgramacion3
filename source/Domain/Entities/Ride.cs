using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Ride
    {
        public DateTime Date { get; set; }
        public Ride()
        {
            Date = DateTime.Now;
    }
    }
}
