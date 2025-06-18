using KnowledgeCheck.DAL.Data;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Helpers;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Result>> GetByUserIdAsync(string userId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }


        public async Task<PagedList<Result>> GetAllPaginatedAsync(ResultParameters parameters, ISortHelper<Result> sortHelper, CancellationToken cancellationToken = default)
        {
            var query = _dbSet
                .Include(r => r.User)
                .Include(r => r.Test)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.UserId))
                query = query.Where(r => r.UserId == parameters.UserId);

            if (parameters.TestId is not null)
                query = query.Where(r => r.TestId == parameters.TestId);

            if (parameters.TakenFrom.HasValue)
                query = query.Where(r => r.TakenAt >= parameters.TakenFrom.Value);

            if (parameters.TakenTo.HasValue)
                query = query.Where(r => r.TakenAt <= parameters.TakenTo.Value);

            if (parameters.MinScore.HasValue)
                query = query.Where(r => r.Score >= parameters.MinScore.Value);

            if (parameters.MaxScore.HasValue)
                query = query.Where(r => r.Score <= parameters.MaxScore.Value);


            query = sortHelper.ApplySort(query, parameters.OrderBy);

            return await PagedList<Result>.ToPagedListAsync(
                query.AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize,
                cancellationToken
            );
        }

    }
}
