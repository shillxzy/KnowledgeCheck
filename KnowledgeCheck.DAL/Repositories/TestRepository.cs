using KnowledgeCheck.DAL.Data;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Helpers;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(KnowledgeCheckDbContext context) : base(context)
        {
        }

        public async Task<Test?> GetByIdAsync(int id)
        {
            return await _context.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Test test)
        {
            await _context.Tests.AddAsync(test);
        }

        public void Update(Test test)
        {
            _context.Tests.Update(test);
        }

        public void Delete(Test test)
        {
            _context.Tests.Remove(test);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Test?> GetTestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddTestAsync(Test test)
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(Test test)
        {
            throw new NotImplementedException();
        }

        public void DeleteTest(Test test)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITestRepository.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<Test>> GetAllPaginatedAsync(TestParameters parameters, ISortHelper<Test> sortHelper, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Title))
                query = query.Where(t => t.Title.ToLower().Contains(parameters.Title.ToLower()));

            if (parameters.CreatedFrom is not null)
                query = query.Where(t => t.CreatedAt >= parameters.CreatedFrom);

            if (parameters.CreatedTo is not null)
                query = query.Where(t => t.CreatedAt <= parameters.CreatedTo);

            query = sortHelper.ApplySort(query, parameters.OrderBy);

            return await PagedList<Test>.ToPagedListAsync(
                query.AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize,
                cancellationToken
            );
        }

    }
}