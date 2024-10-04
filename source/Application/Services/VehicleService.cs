using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        //el encargado de crear los objetos es el service
        //aca recibo el Dto de la request y armo el Dto de la response
        public VehicleDto CreateVehicle(CreateVehicleRequest request)
        {
            Vehicle newVehicle = new Vehicle(request.brand, request.year, request.model);
            _vehicleRepository.Add(newVehicle);
            return VehicleDto.Create(newVehicle);//aca creo un dto de respuesta del vehiculo a partir del newVehicle y lo retorno
        }
        //el metodo que creará al dto es un metodo static lo cual permite ser llamado sin la necesidad de que la clase sea instanciada
        //los metodos static pertenecen a la clase y no al objeto por lo que al llamarlos se llama a la clase

        public void DeleteVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Delete(vehicle);
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetVehicleById(id);
        }

        //GetByVehicleById
        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAll();
        }


    }
}
