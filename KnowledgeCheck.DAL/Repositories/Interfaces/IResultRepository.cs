using KnowledgeCheck.DAL.Entities;
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

        Task<IEnumerable<Result>> GetByUserIdAsync(int userId);
    }
}
