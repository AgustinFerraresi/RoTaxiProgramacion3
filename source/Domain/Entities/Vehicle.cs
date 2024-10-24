using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public List<Driver> Drivers { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Vehicle(string brand, int year, string model)
        {
            Brand = brand;
            Year = year;
            Model = model;
        }

        public void AddDriver(Driver driver)
        {
            if (Drivers.Contains(driver))
            {
                return;
            }
            Drivers.Add(driver);
            return;
        }

        //public IReadOnlyList<Driver> Drivers => _drivers;
    }
}
