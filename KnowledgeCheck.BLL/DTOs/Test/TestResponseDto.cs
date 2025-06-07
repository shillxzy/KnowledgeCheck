using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Test
{
    public class TestResponseDto : TestDto
    {
        public List<string> Questions { get; set; } = new();
        public int QuestionCount { get; set; }
    }
}
