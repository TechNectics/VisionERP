using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T identity);
        T Update(T identity);
        T Delete(T id);
        T GetById(int id);
        IEnumerable<T> GetAll();        
       }
}
