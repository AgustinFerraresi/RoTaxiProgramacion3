using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        //si driver tuviese metodos exclusivos respecto a las demas clases sus firmas irian aca

        public Driver GetById(int id);

    }
}
