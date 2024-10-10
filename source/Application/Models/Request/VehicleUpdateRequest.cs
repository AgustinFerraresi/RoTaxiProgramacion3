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
        public string? brand { get; set; }
        public int? year { get; set; }
        public string? model { get; set; }
    }
}
