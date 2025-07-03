using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Domain.Entities;
using SGBL.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Infrastructure.Persistence.Repositories
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        private readonly ApplicationContext _dbContext;

        public GeneroRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
