using KnowledgeCheck.BLL.DTOs.Result;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;

namespace KnowledgeCheck.BLL.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public async Task<ResultResponseDto> GetByIdAsync(int id)
        {
            var result = await _resultRepository.GetByIdAsync(id) ?? throw new ResultNotFoundException();
            return result.Adapt<ResultResponseDto>();
        }

        public async Task<IEnumerable<ResultResponseDto>> GetByUserIdAsync(int userId)
        {
            var results = await _resultRepository.GetByUserIdAsync(userId);
            return results.Adapt<IEnumerable<ResultResponseDto>>();
        }

        public async Task<ResultResponseDto> CreateResultAsync(ResultCreateDto dto)
        {
            var result = dto.Adapt<Result>();
            await _resultRepository.AddAsync(result);
            await _resultRepository.SaveChangesAsync();

            return result.Adapt<ResultResponseDto>();
        }

        public async Task UpdateResultAsync(int id, ResultUpdateDto dto)
        {
            var result = await _resultRepository.GetByIdAsync(id) ?? throw new ResultNotFoundException();

            dto.Adapt(result);
            _resultRepository.Update(result);
            await _resultRepository.SaveChangesAsync();
        }

        public async Task DeleteResultAsync(int id)
        {
            var result = await _resultRepository.GetByIdAsync(id) ?? throw new ResultNotFoundException();

            _resultRepository.Delete(result);
            await _resultRepository.SaveChangesAsync();
        }
    }
}
