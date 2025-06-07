using KnowledgeCheck.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task<Test?> GetTestByIdAsync(int id);
        Task AddTestAsync(Test test);
        void UpdateTest(Test test);
        void DeleteTest(Test test);
        Task<bool> SaveChangesAsync();
    }
}
