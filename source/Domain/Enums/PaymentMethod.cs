using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Efectivo")]
        Cash, //tiene el valor numerico de 0

        [Display(Name = "Pago Digital")]
        DigitalPayment //tiene el valor numerico de 1
    }
}
