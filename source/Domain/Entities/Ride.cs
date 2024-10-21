using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Ride
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }

        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger passenger { get; set; }
    }
}
