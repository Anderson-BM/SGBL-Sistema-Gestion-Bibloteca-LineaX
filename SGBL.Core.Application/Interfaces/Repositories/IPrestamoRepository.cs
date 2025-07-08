using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Interfaces.Repositories
{
    public interface IPrestamoRepository : IGenericRepository<Prestamo>
    {
        Task<List<Prestamo>> GetPrestamosConLibrosYUsuariosAsync();
    }

}
