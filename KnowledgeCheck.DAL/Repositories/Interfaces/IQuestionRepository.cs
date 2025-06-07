using KnowledgeCheck.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<Question?> GetByIdAsync(int id);
        Task AddAsync(Question question);
        void Update(Question question);
        void Delete(Question question);
        Task SaveChangesAsync();
    }
}
