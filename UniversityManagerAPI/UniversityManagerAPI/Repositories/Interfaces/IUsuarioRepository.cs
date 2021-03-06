﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Models;

namespace UniversityManagerAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetUsuarioLogin(Usuario usuario);
    }
}
