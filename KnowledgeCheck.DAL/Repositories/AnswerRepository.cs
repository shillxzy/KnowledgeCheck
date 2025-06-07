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
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(KnowledgeCheckDbContext context) : base(context) { }

        public async Task<Answer?> GetByIdAsync(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task AddAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
        }

        public void Update(Answer answer)
        {
            _context.Answers.Update(answer);
        }

        public void Delete(Answer answer)
        {
            _context.Answers.Remove(answer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
