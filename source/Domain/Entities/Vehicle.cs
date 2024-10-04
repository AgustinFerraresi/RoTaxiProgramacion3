using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Vehicle
    {
        
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Vehicle(string brand, int year, string model)
        {
            Brand = brand;
            Year = year;
            Model = model;
        }
    }
}
