using KnowledgeCheck.BLL.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<QuestionResponseDto>> GetByTestIdAsync(int testId);
        Task<QuestionResponseDto> CreateQuestionAsync(QuestionCreateDto dto);
        Task UpdateQuestionAsync(int id, QuestionUpdateDto dto);
        Task DeleteQuestionAsync(int id);
    }
}
