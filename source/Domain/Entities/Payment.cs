using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Payment
    {
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public Payment(float amount, string paymentMethod)
        {
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
