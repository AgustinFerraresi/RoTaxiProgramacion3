using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class VehicleUpdateRequest
    {
        public string? Brand { get; set; }
        public int? Year { get; set; }
        public string? Model { get; set; }
    }
}
