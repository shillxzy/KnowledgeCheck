using KnowledgeCheck.BLL.DTOs.Question;
using KnowledgeCheck.BLL.DTOs.Result;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Helpers;
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
        Task<IEnumerable<ResultResponseDto>> GetByUserIdAsync(string userId);
        Task<ResultResponseDto> CreateResultAsync(ResultCreateDto dto);
        Task UpdateResultAsync(int id, ResultUpdateDto dto);
        Task DeleteResultAsync(int id);
        Task<IEnumerable<ResultResponseDto>> GetAllAsync();
        Task<PagedList<ResultResponseDto>> GetPaginatedAsync(ResultParameters parameters, CancellationToken cancellationToken);
    }
}
