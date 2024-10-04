using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data   
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(ApplicationContext context) : base(context)
        {

        }
    }
}



//El IpassengerRepository se implementa aca por si hubiese algun metodo que no esta en baseRepository
//static List<Passenger> passengers = []; //aca se guardan los pasajeros mas adelante sera en la db