using KnowledgeCheck.BLL.DTOs.Question;
using KnowledgeCheck.BLL.Exceptions;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.DAL.Entities;
using KnowledgeCheck.DAL.Repositories.Interfaces;
using Mapster;

namespace KnowledgeCheck.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionResponseDto> GetByIdAsync(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id) ?? throw new QuestionNotFoundException();
            return question.Adapt<QuestionResponseDto>();
        }

        public async Task<IEnumerable<QuestionResponseDto>> GetByTestIdAsync(int testId)
        {
            var questions = await _questionRepository.GetByTestIdAsync(testId);
            return questions.Adapt<IEnumerable<QuestionResponseDto>>();
        }

        public async Task<QuestionResponseDto> CreateQuestionAsync(QuestionCreateDto dto)
        {
            var question = dto.Adapt<Question>();
            await _questionRepository.AddAsync(question);
            await _questionRepository.SaveChangesAsync();

            return question.Adapt<QuestionResponseDto>();
        }

        public async Task UpdateQuestionAsync(int id, QuestionUpdateDto dto)
        {
            var question = await _questionRepository.GetByIdAsync(id) ?? throw new QuestionNotFoundException();

            dto.Adapt(question);
            _questionRepository.Update(question);
            await _questionRepository.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id) ?? throw new QuestionNotFoundException();

            _questionRepository.Delete(question);
            await _questionRepository.SaveChangesAsync();
        }
    }
}
