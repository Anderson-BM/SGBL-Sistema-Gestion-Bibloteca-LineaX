using AutoMapper;
using Microsoft.AspNetCore.Http;
using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Genero;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Services
{
    public class GeneroService : GenericService<SaveGeneroViewModel, GeneroViewModel, Genero>, IGeneroService
    {
        private readonly IGeneroRepository _GeneroRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GeneroService(IGeneroRepository generoRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(generoRepository, mapper)
        {
            _GeneroRepository = generoRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generoList = await _GeneroRepository.GetAllWithIncludeAsync(new List<string> { "Libro" });

            return generoList.Select(genero => new GeneroViewModel
            {
                Id = genero.Id,
                Name = genero.Name,
                ImageUrl = genero.ImageUrl,

            }).ToList();
        }

       public async Task<List<SaveGeneroViewModel>>GetAllViewModelWithFilters(FilterLibroViewModel filters)
        {
            var generoList = await _GeneroRepository.GetAllWithIncludeAsync(new List<string> { "Libro" });

            var listViewModels = generoList.Select(genero => new SaveGeneroViewModel
            {
                Name = genero.Name,
                Id = genero.Id,
            }).ToList();

            return listViewModels;
        }
    }
}