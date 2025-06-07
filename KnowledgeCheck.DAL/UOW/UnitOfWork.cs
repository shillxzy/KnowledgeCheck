using KnowledgeCheck.DAL.Data;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KnowledgeCheckDbContext _context;

        public IUserRepository Users { get; }
        public ITestRepository Tests { get; }
        public IQuestionRepository Questions { get; }
        public IAnswerRepository Answers { get; }
        public IResultRepository Results { get; }

        public UnitOfWork(KnowledgeCheckDbContext context,
                          IUserRepository userRepository,
                          ITestRepository testRepository,
                          IQuestionRepository questionRepository,
                          IAnswerRepository answerRepository,
                          IResultRepository resultRepository)
        {
            _context = context;

            Users = userRepository;
            Tests = testRepository;
            Questions = questionRepository;
            Answers = answerRepository;
            Results = resultRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
