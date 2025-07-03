using SGBL.Core.Application.ViewModels.Genero;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Domain.Entities;


namespace SGBL.Core.Application.Interfaces.Services
{
    public interface IGeneroService : IGenericService<SaveGeneroViewModel, GeneroViewModel, Genero>
    {
        Task<List<SaveGeneroViewModel>> GetAllViewModelWithFilters(FilterLibroViewModel filters);
       
    }
}
