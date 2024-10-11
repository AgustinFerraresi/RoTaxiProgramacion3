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
        List<RideDto> GetAll();
        RideDto? GetById(int id);
        RideDto Create(RideCreateRequest request);
        void Delete(int id);
        void Update(int id, RideUpdateRequest request);

    }
}
