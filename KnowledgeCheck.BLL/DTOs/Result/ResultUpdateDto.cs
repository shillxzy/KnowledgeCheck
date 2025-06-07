using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Result
{
    public class ResultUpdateDto
    {
        public int Id { get; set; } 
        public int Score { get; set; }
        public DateTime TakenAt { get; set; }
    }
}
