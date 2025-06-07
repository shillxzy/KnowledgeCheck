using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Question
{
    public class QuestionResponseDto : QuestionDto
    {
        public List<string> Answers { get; set; } = new();
    }
}
