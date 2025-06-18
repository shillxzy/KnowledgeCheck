using KnowledgeCheck.BLL.DTOs.Question;
using KnowledgeCheck.BLL.DTOs.Result;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Entities.HelpModels;
using KnowledgeCheck.DAL.Helpers;
using KnowledgeCheck.DAL.Repositories;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;
using MapsterMapper;

namespace KnowledgeCheck.BLL.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;
        private readonly ISortHelper<Result> _resultSortHelper;

        public ResultService(IResultRepository resultRepository, IMapper mapper, ISortHelper<Result> resultSortHelper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
            _resultSortHelper = resultSortHelper;
        }

        public async Task<PagedList<ResultResponseDto>> GetPaginatedAsync(ResultParameters parameters, CancellationToken cancellationToken)
        {
            var pagedResults = await _resultRepository.GetAllPaginatedAsync(
                parameters,
                new SortHelper<Result>(),  
                cancellationToken);

            var mapped = pagedResults.Select(r => new ResultResponseDto
            {
                Id = r.Id,
                UserId = r.UserId,
                TestId = r.TestId,
                Score = r.Score,
                TakenAt = r.TakenAt,
                UserName = r.User?.UserName ?? string.Empty,
                TestName = r.Test?.Title ?? string.Empty
            }).ToList();

            return new PagedList<ResultResponseDto>(
                mapped,
                pagedResults.TotalCount,
                pagedResults.CurrentPage,
                pagedResults.PageSize);
        }


        public async Task<IEnumerable<ResultResponseDto>> GetAllAsync()
        {
            var answers = await _resultRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResultResponseDto>>(answers);
        }
        public async Task<ResultResponseDto> GetByIdAsync(int id)
        {
            var result = await _resultRepository.GetByIdAsync(id) ?? throw new ResultNotFoundException();
            return result.Adapt<ResultResponseDto>();
        }

        public async Task<IEnumerable<ResultResponseDto>> GetByUserIdAsync(string userId)
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
