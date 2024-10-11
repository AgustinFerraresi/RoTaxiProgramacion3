using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Request
{
    public class RideUpdateRequest
    {
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Destination { get; set; }
        public float? Cost { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
