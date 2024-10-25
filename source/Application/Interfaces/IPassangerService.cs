using Application.Models;
using Application.Models.Request;
using Domain.Classes;
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
        List<PassengerDto> GetAll();
        PassengerDto? GetPassengerById(int id);
        PassengerDto? GetPassengerByName(string name);
        void UpdatePassenger(int id, PassengerUpdateRequest request, int userId);
        void DeletePassenger(int id, int userId);
    }
}
