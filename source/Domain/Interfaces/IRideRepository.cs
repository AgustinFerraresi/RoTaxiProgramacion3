﻿using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRideRepository : IBaseRepository<Ride>
    {
        Ride GetRideById(int id);
    }
}