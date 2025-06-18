using KnowledgeCheck.BLL.DTOs.Test;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Helpers;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeCheck.BLL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly ISortHelper<Test> _testSortHelper;
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<TestResponseDto> GetByIdAsync(int id)
        {
            var test = await _testRepository.GetTestByIdAsync(id) ?? throw new TestNotFoundException();
            return test.Adapt<TestResponseDto>();
        }

        public async Task<PagedList<Test>> GetPaginatedAsync(TestParameters parameters, CancellationToken cancellationToken)
        {
            return await _testRepository.GetAllPaginatedAsync(parameters, _testSortHelper, cancellationToken);
        }

        public async Task<IEnumerable<TestResponseDto>> GetAllAsync()
        {
            var tests = await _testRepository.GetAllTestsAsync();
            return tests.Adapt<IEnumerable<TestResponseDto>>();
        }

        public async Task<TestResponseDto> CreateTestAsync(TestCreateDto dto)
        {
            var test = dto.Adapt<Test>();
            await _testRepository.AddAsync(test);
            await _testRepository.SaveChangesAsync();

            return test.Adapt<TestResponseDto>();
        }

        public async Task UpdateTestAsync(int id, TestUpdateDto dto)
        {
            var test = await _testRepository.GetTestByIdAsync(id) ?? throw new TestNotFoundException();

            dto.Adapt(test);
            _testRepository.Update(test);
            await _testRepository.SaveChangesAsync();
        }

        public async Task DeleteTestAsync(int id)
        {
            var test = await _testRepository.GetTestByIdAsync(id) ?? throw new TestNotFoundException();

            _testRepository.Delete(test);
            await _testRepository.SaveChangesAsync();
        }
    }
}
