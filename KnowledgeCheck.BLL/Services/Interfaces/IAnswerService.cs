using KnowledgeCheck.BLL.DTOs.Answer;
using KnowledgeCheck.BLL.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<AnswerResponseDto>> GetByQuestionIdAsync(int questionId);
        Task<AnswerResponseDto> CreateAnswerAsync(AnswerCreateDto dto);
        Task UpdateAnswerAsync(int id, AnswerUpdateDto dto);
        Task DeleteAnswerAsync(int id);
        Task<IEnumerable<AnswerResponseDto>> GetAllAsync();

    }
}
