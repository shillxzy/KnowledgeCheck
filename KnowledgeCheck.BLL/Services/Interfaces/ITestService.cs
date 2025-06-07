using KnowledgeCheck.BLL.DTOs.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services.Interfaces
{
    public interface ITestService
    {
        Task<TestResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<TestResponseDto>> GetAllAsync();
        Task<TestResponseDto> CreateTestAsync(TestCreateDto dto);
        Task UpdateTestAsync(int id, TestUpdateDto dto);
        Task DeleteTestAsync(int id);
    }
}
