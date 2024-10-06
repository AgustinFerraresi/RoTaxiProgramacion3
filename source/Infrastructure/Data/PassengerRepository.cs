﻿using Domain.Classes;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data   
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        private readonly ApplicationContext _context;
        public PassengerRepository(ApplicationContext context) : base(context)
        {

        }

        public Passenger? GetPassengerById(int id)
        {
            return _context.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        }
    }
}