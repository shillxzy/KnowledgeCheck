using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Exceptions
{
    public class QuestionNotFoundException : Exception
    {
        public QuestionNotFoundException(string message = "Question not found.") : base(message) { }
    }
}
