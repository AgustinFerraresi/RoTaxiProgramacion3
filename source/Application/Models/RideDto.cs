using Domain.Classes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RideDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
                
        public static RideDto Create(Ride ride)
        {
            var dto = new RideDto();
            dto.Id = ride.Id;
            dto.Date = ride.Date;
            dto.Cost = ride.Cost;
            dto.PaymentMethod = ride.PaymentMethod;

            return dto;
        }
    }
}
