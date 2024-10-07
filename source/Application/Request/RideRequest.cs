using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class RideRequest
    {
        public float Cost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
