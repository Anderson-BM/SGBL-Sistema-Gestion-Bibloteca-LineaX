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
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        private readonly ApplicationContext _dbContext;

        public LibroRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
