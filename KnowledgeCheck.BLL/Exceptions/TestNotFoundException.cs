using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Exceptions
{
    public class TestNotFoundException : Exception
    {
        public TestNotFoundException(string message = "Test not found.") : base(message) { }
    }
}
