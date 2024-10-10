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
        void DeletePassenger(int id);
        List<PassengerDto> GetAllPassenger();
        PassengerDto? GetPassengerById(int id);
        void UpdatePassenger(int id, PassengerUpdateRequest request);
    }
}
