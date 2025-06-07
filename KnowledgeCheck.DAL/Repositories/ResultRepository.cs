using KnowledgeCheck.DAL.Data;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories
{
    public class ResultRepository : GenericRepository<Result>, IResultRepository
    {
        public ResultRepository(KnowledgeCheckDbContext context) : base(context) { }

        public async Task<Result?> GetByIdAsync(int id)
        {
            return await _context.Results.FindAsync(id);
        }

        public async Task AddAsync(Result result)
        {
            await _context.Results.AddAsync(result);
        }

        public void Update(Result result)
        {
            _context.Results.Update(result);
        }

        public void Delete(Result result)
        {
            _context.Results.Remove(result);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
