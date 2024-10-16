using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
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
            Vehicle newVehicle = new Vehicle(request.brand, request.year, request.model, request.patente);
            _vehicleRepository.Add(newVehicle);
            return VehicleDto.Create(newVehicle);//aca creo un dto de respuesta del vehiculo a partir del newVehicle y lo retorno
        }
        //el metodo que creará al dto es un metodo static lo cual permite ser llamado sin la necesidad de que la clase sea instanciada
        //los metodos static pertenecen a la clase y no al objeto por lo que al llamarlos se llama a la clase

        public bool DeleteVehicle(int id)
        {
            var vehicleToDelete = _vehicleRepository.GetById(id);
            if (vehicleToDelete != null)
            {
                _vehicleRepository.Delete(vehicleToDelete);
                return true;
            }
            return false;
        }
        
        public VehicleDto GetVehicleById(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            return vehicle != null ? VehicleDto.Create(vehicle) : null; 
        }

        public List<VehicleDto> GetAllVehicles()
        {
            var vehicles = _vehicleRepository.GetAll();
            return vehicles.Select(vehicle => VehicleDto.Create(vehicle)).ToList();
        }

        public VehicleDto UpdateVehicle(VehicleUpdateRequest request,int id)
        {
            Vehicle vehicleToUpdate = _vehicleRepository.GetById(id);
            vehicleToUpdate.Brand = request.brand ?? vehicleToUpdate.Brand;
            vehicleToUpdate.Model = request.model ?? vehicleToUpdate.Model;
            vehicleToUpdate.Year = request.year.HasValue ? request.year.Value : vehicleToUpdate.Year;
            vehicleToUpdate.Patente = request.patente ?? vehicleToUpdate.Patente;

            _vehicleRepository.Update(vehicleToUpdate);
            return VehicleDto.Create(vehicleToUpdate);
        }
    }
}
