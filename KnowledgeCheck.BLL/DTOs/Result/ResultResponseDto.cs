using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.Result
{
    public class ResultResponseDto : ResultDto
    {
        public DateTime CompletedAt { get; set; }
    }

}
