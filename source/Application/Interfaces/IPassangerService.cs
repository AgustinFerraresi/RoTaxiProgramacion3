using Application.Request;
using Application.Response;
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
        PassengerDto CreatePassenger(PassengerRequest request);
        void DeletePassenger(int id);
        List<PassengerDto> GetAllPassenger();
        PassengerDto? GetPassengerById(int id);
    }
}
