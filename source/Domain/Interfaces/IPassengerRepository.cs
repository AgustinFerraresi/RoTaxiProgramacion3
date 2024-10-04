using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPassengerRepository : IBaseRepository<Passenger>
    {
        //como no tiene de momento ningun metodo extra no se le agrega nada acá
    }
}
