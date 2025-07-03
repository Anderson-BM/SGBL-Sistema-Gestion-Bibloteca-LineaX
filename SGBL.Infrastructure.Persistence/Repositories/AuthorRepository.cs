using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Domain.Entities;
using SGBL.Infrastructure.Persistence.Context;


namespace SGBL.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly ApplicationContext _dbContext;

        public AuthorRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
