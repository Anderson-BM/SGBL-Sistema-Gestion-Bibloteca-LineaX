using Microsoft.EntityFrameworkCore;
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
    public class ReservasRepository : GenericRepository<Reservas>, IReservasRepository
    {
        private readonly ApplicationContext _context;

        public ReservasRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Reservas>> GetReservasConLibrosYUsuarios()
        {
            return await _context.Reservas
                .Include(r => r.Libro)
              //  .Include(r => r.UsuarioId)
                .ToListAsync();
        }
    }
}