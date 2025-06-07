using KnowledgeCheck.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITestRepository Tests { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        IResultRepository Results { get; }

        Task<int> SaveChangesAsync();
    }

}
