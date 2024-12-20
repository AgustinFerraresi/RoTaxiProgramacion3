﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        List<T> GetAll();
        T? GetById<TId> (TId id);
        void Update(T entity);
        void Delete(T entity);

    }
}
