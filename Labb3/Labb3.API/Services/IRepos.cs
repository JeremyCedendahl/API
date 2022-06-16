using Labb3Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3.API.Services
{
    public interface IRepos<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Add(T newEntity);

        Task<T> GetSingle(int id);
    }
}