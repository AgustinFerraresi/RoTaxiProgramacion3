using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Vehicle
    {
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Patente { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Vehicle(string brand, int year, string model, string patente)
        {
            Brand = brand;
            Year = year;
            Model = model;
            Patente = patente;
        }
    }
}
