﻿using RentC_DbConnection.Models;
using System.Linq;

namespace RentC_InMemoryRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}