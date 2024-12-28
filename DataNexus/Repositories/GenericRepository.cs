using Dapper;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Constants.ApplicationConstants;

namespace DataNexus.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {

            this._context = context;

        }
        public async Task<T> Add(T entity)
        {
            await this._context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Delete(T id)
        {
            this._context.Set<T>().Remove(id);
            return id;
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            this._context.Update(entity);
            return entity;

        }                   
    }
}
