using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Entities.HelpModels
{
    public class UserParameters : QueryStringParameters
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
