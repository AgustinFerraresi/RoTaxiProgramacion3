using Domain.Classes;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationContext _context;
        public VehicleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        //public Vehicle? GetVehicleById(int id)
        //{
        //    return _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        //}
    }
}


//aca lo que se hace es inyectar el contexto en la siguiente linea:
//"private readonly ApplicationContext _context;"
//y lo que hago es pasarselo al constructor de la clase padre osea BaseRepository que será inicializado en su constructor
//asi es como paso el contexto al padre: "public VehicleRepository(ApplicationContext context) : base(context)"
//pero ademas tengo que iniciarlizarlo en este constructor ya que tengo un metodo exclusivo de este repositorio por lo cual
//aca tambien necesito el contexto

