﻿using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Repositories.Interfaces
{
    public interface ITestRepository : IGenericRepository<Test>
    {
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task<Test?> GetTestByIdAsync(int id);
        Task AddAsync(Test test);
        void Update(Test test);
        void Delete(Test test);
        Task<bool> SaveChangesAsync();
        Task<PagedList<Test>> GetAllPaginatedAsync(TestParameters parameters, ISortHelper<Test> sortHelper, CancellationToken cancellationToken = default);
    }
}
