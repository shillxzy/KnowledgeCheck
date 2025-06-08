using KnowledgeCheck.BLL.DTOs.Answer;
using KnowledgeCheck.BLL.DTOs.User;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;
using MapsterMapper;

namespace KnowledgeCheck.BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public async Task<IEnumerable<AnswerResponseDto>> GetAllAsync()
        {
            var answers = await _answerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnswerResponseDto>>(answers);
        }

        public async Task<AnswerResponseDto> GetByIdAsync(int id)
        {
            var answer = await _answerRepository.GetByIdAsync(id) ?? throw new AnswerNotFoundException();
            return answer.Adapt<AnswerResponseDto>();
        }

        public async Task<IEnumerable<AnswerResponseDto>> GetByQuestionIdAsync(int questionId)
        {
            var answers = await _answerRepository.GetByQuestionIdAsync(questionId);
            return answers.Adapt<IEnumerable<AnswerResponseDto>>();
        }

        public async Task<AnswerResponseDto> CreateAnswerAsync(AnswerCreateDto dto)
        {
            var answer = dto.Adapt<Answer>();
            await _answerRepository.AddAsync(answer);
            await _answerRepository.SaveChangesAsync();

            return answer.Adapt<AnswerResponseDto>();
        }

        public async Task UpdateAnswerAsync(int id, AnswerUpdateDto dto)
        {
            var answer = await _answerRepository.GetByIdAsync(id) ?? throw new AnswerNotFoundException();

            dto.Adapt(answer);
            _answerRepository.Update(answer);
            await _answerRepository.SaveChangesAsync();
        }

        public async Task DeleteAnswerAsync(int id)
        {
            var answer = await _answerRepository.GetByIdAsync(id) ?? throw new AnswerNotFoundException();

            _answerRepository.Delete(answer);
            await _answerRepository.SaveChangesAsync();
        }
    }

}
