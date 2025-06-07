using KnowledgeCheck.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories.Interfaces
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<Answer?> GetByIdAsync(int id);
        Task AddAsync(Answer answer);
        void Update(Answer answer);
        void Delete(Answer answer);
        Task SaveChangesAsync();
        Task<IEnumerable<Answer>> GetByQuestionIdAsync(int questionId);
    }
}
