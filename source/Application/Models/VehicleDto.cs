﻿using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    //este es el dto de respuesta
    public class VehicleDto
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }

        public static VehicleDto Create(Vehicle vehicle)
        {
            var dto = new VehicleDto();

            dto.Brand = vehicle.Brand;
            dto.Year = vehicle.Year;
            dto.Model = vehicle.Model;

            return dto;
        }
    }
}