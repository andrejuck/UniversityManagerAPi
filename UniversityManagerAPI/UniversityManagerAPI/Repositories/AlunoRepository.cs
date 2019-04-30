using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Context;
using UniversityManagerAPI.Models;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApiDBContext context) : base(context)
        {
        }

        public Aluno Create(Aluno model)
        {
            throw new NotImplementedException();
        }
    }
}
