using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Result
{
    public class ResultResponseDto : ResultDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public DateTime TakenAt { get; set; }
        public int Score { get; set; }
        public string UserName { get; set; }
        public string TestName { get; set; }
    }

}
