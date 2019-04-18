using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Models;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public async Task<Usuarios> Create(Usuarios model)
        {
            return model;
        }
    }
}
