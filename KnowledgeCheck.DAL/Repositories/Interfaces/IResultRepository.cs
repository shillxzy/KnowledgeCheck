using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories.Interfaces
{
    public interface IResultRepository : IGenericRepository<Result>
    {
        Task<Result?> GetByIdAsync(int id);
        Task AddAsync(Result result);
        void Update(Result result);
        void Delete(Result result);
        Task SaveChangesAsync();
        Task<IEnumerable<Result>> GetByUserIdAsync(string userId);
        Task<PagedList<Result>> GetAllPaginatedAsync(ResultParameters parameters, ISortHelper<Result> sortHelper, CancellationToken cancellationToken = default);
        
    }
}
