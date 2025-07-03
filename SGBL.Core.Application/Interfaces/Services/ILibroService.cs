using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Interfaces.Services
{
    public interface ILibroService : IGenericService<SaveLibroViewModel, LibroViewModel, Libro>
    {
        Task<List<LibroViewModel>> GetAllViewModelWithFilters(FilterLibroViewModel filters);
    }
}
