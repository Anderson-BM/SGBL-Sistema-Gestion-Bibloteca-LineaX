using SGBL.Core.Application.ViewModels.Author;
using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Interfaces.Services
{
    public interface IAuthorService : IGenericService<SaveAutorViewModel, AuthorViewModel, Author>
    {
        Task<List<AuthorViewModel>> GetAllViewModel();
    }
}
