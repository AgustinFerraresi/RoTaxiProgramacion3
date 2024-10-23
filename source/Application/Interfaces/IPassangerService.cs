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
        PassengerDto Create(PassengerCreateRequest request);
        void Delete(int id, int userId);
        List<PassengerDto> GetAll();
        PassengerDto? GetById(int id);
        void Update(int id, PassengerUpdateRequest request, int userId);
    }
}
