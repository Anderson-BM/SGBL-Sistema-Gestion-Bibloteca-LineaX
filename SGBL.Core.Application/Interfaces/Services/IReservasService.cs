using SGBL.Core.Application.ViewModels.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Interfaces.Services
{
    public interface IReservasService
    {
        Task<List<ReservasViewModel>> GetAll();
        Task Add(SaveReservasViewModel model);
        Task<bool> PuedeReservar(int libroId, string usuarioId);
    }
}
