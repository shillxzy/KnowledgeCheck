using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message = "Validation failed.") : base(message) { }
    }
}
