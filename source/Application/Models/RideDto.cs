﻿using Domain.Classes;
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
        public string Passenger {  get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public string PaymentMethod { get; set; }
                
        public static RideDto Create(Ride ride)
        {
            var dto = new RideDto();
            dto.Id = ride.Id;
            dto.Passenger = ride.Passenger?.Name != null ? ride.Passenger.Name : "Desconocido";
            dto.Location = ride.Location;
            dto.Destination = ride.Destination;
            dto.Date = ride.Date;
            dto.Cost = ride.Cost;
            dto.PaymentMethod = ride.PaymentMethod.ToString();

            return dto;
        }
    }
}
