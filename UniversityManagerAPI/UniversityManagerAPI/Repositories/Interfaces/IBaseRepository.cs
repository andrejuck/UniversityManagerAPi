using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Models;

namespace UniversityManagerAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel 
    {
        Task<T> Create(T model);
        Task<T> GetAsync(int id);
    }
}
