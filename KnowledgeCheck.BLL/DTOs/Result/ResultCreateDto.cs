using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Result
{
    public class ResultCreateDto
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public double Score { get; set; }
    }

}
