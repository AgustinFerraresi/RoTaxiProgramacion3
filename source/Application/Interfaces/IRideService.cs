using Application.Models;
using Application.Models.Request;
using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRideService
    {
        RideDto CreateRide(RideCreateRequest request, int userId);
        List<RideDto> GetAll();
        RideDto? GetById(int id);
        void Update(int id, RideUpdateRequest request, int userId);
        void Delete(int id, int userId);
    }
}
