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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(KnowledgeCheckDbContext context) : base(context) { }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
        }

        public void Delete(Question question)
        {
            _context.Questions.Remove(question);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
