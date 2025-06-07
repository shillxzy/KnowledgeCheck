using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Result
{
    public class ResultDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string TestTitle { get; set; } = string.Empty;
        public double Score { get; set; }
    }
}
