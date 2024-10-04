using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    //este dto es el que estará en el controller para crear un vehiculo
    public class CreateVehicleRequest
    {
        //estos parametros seran rellenados por el usurio
        [Required]
        public string brand { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string model { get; set; }
    }
}
