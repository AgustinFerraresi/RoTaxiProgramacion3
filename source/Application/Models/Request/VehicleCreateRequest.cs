using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    //este dto es el que estará en el controller para crear un vehiculo
    public class VehicleCreateRequest
    {
        //estos parametros seran rellenados por el usurio
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Model { get; set; }
    }
}
