using KnowledgeCheck.BLL.DTOs.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services.Interfaces
{
    public interface IResultService
    {
        Task<ResultResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<ResultResponseDto>> GetByUserIdAsync(int userId);
        Task<ResultResponseDto> CreateResultAsync(ResultCreateDto dto);
        Task UpdateResultAsync(int id, ResultUpdateDto dto);
        Task DeleteResultAsync(int id);
    }
}
