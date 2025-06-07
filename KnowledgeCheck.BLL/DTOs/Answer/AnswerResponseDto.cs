using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Answer
{
    public class AnswerResponseDto : AnswerDto
    {
        public bool IsCorrect { get; set; }
    }
}
