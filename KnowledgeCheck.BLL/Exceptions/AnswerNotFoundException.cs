using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Exceptions
{
    public class AnswerNotFoundException : Exception
    {
        public AnswerNotFoundException(string message = "Answer not found.") : base(message) { }
    }
}
