using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle
    {
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public List<Driver> _drivers { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Vehicle(string brand, int year, string model)
        {
            Brand = brand;
            Year = year;
            Model = model;
            _drivers = new List<Driver>();
        }

        public void AddDriver(Driver driver)
        {
            if (_drivers.Contains(driver))
            {
                return;
            }
            _drivers.Add(driver);
            return;
        }

        public IReadOnlyList Drivers => _drivers;
    }
