using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPassangerService
    {
        PassengerDto CreatePassenger(PassengerCreateRequest request);
        List<PassengerDto> GetAllPassengers();
        PassengerDto? GetPassengerById(int id);
        void UpdatePassenger(int id, PassengerUpdateRequest request, int userId);
        void DeletePassenger(int id, int userId);
    }
}
