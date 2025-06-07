using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Exceptions
{
    public class ResultNotFoundException : Exception
    {
        public ResultNotFoundException(string message = "Result not found.") : base(message) { }
    }
}
