using AutoMapper;
using Microsoft.AspNetCore.Http;
using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Author;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Services
{
    public class AuthorService : GenericService<SaveAutorViewModel, AuthorViewModel, Author>, IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository,  IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(authorRepository, mapper)
        {
            _AuthorRepository = authorRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<List<AuthorViewModel>> GetAllViewModel()
        {
            var LibrosList = await _AuthorRepository.GetAllWithIncludeAsync(new List<string> { "Libro"});

            return LibrosList.Select(Libro => new AuthorViewModel
            {
                Name = Libro.Name,
                Id = Libro.Id,
                LibrosQuantity = Libro.Libro.Count(),
                ImageUrl = Libro.ImageUrl,
            }).ToList();
        }
    }
}

