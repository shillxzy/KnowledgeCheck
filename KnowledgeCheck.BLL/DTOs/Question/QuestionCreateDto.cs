﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Question
{
    public class QuestionCreateDto
    {
        public string Text { get; set; } = string.Empty;
        public int TestId { get; set; }
    }
}
