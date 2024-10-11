using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class RideCreateRequest
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public float Cost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
