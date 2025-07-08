using SGBL.Core.Application.ViewModels.Prestamo;
using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Interfaces.Services
{
    public interface IPrestamoService : IGenericService<SavePrestamoViewModel, PrestamoViewModel, Prestamo>
    {
        Task AprobarPrestamoAsync(int id);
        Task RechazarPrestamoAsync(int id);
        Task DevolverPrestamoAsync(int id);
    }

}
