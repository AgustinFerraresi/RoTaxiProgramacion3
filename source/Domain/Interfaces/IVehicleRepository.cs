using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Vehicle GetVehicleById(int id);
        //metodo extra para esta interfaz
    }
}
