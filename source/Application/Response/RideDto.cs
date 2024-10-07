using Domain.Classes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class RideDto
    {
        public float Cost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }


        public static RideDto Create(Ride ride)
        {
            var dto = new RideDto();
            dto.Cost = ride.Cost;
            dto.PaymentMethod = ride.PaymentMethod;
            dto.Id = ride.Id;
            dto.Date = ride.Date;

            return dto;
        }
    }
}
