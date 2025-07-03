using AutoMapper;
using Microsoft.AspNetCore.Http;
using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Domain.Entities;


namespace SGBL.Core.Application.Services
{
    public class LibroService : GenericService<SaveLibroViewModel, LibroViewModel, Libro>, ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository libroRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(libroRepository, mapper)
        {
            _libroRepository = libroRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public async Task<List<LibroViewModel>> GetAllViewModel()
        {
            var seriesList = await _libroRepository.GetAllWithIncludeAsync(new List<string> { "Author", "Genero" });

            return seriesList.Select(series => new LibroViewModel
            {
                Name = series.Name,
                Id = series.Id,
                ImageUrl = series.ImageUrl,
                Descrition = series.Descrition,
                AuthorId = series.Author.Id,
                GeneroId = series.Genero.Id,
                AuthorName = series.Author.Name,
                GeneroName = series.Genero.Name


            }).ToList();
        }

        public async Task<List<LibroViewModel>> GetAllViewModelWithFilters(FilterLibroViewModel filters)
        {
            var seriesList = await _libroRepository.GetAllWithIncludeAsync(new List<string> { "Author", "Genero" });

            var listViewModels = seriesList.Select(s => new LibroViewModel
            {
                Name = s.Name,
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                AuthorId = s.Author.Id,
                Descrition = s.Descrition,
                GeneroId = s.Genero.Id,
                AuthorName = s.Author.Name,
                GeneroName = s.Genero.Name
            }).ToList();

            if (filters.AuthorId != null)
            {
                listViewModels = listViewModels.Where(s => s.AuthorId == filters.AuthorId.Value).ToList();
            }

            if (filters.GeneroId.HasValue)
            {
                listViewModels = listViewModels.Where(s => s.GeneroId == filters.GeneroId.Value).ToList();
            }

            return listViewModels;
        }
    }
}
