using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Context;
using UniversityManagerAPI.Models;

namespace UniversityManagerAPI.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApiDBContext _context;

        protected BaseRepository(ApiDBContext context)
        {
            _context = context;
        }
    }
}
