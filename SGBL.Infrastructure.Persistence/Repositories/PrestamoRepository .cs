using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Domain.Entities;
using SGBL.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SGBL.Infrastructure.Persistence.Repositories
{
    public class PrestamoRepository : GenericRepository<Prestamo>, IPrestamoRepository
    {
        private readonly ApplicationContext _dbContext;

        public PrestamoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Prestamo>> GetPrestamosConLibrosYUsuariosAsync()
        {
            return await _dbContext.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .ToListAsync();
        }
    }
}