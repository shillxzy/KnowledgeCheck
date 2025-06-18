using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Entities.HelpModels
{
    public class ResultParameters : QueryStringParameters
    {
        public string? UserId { get; set; }
        public int? TestId { get; set; }
        public DateTime? TakenFrom { get; set; }
        public DateTime? TakenTo { get; set; }
        public int? MinScore { get; set; }
        public int? MaxScore { get; set; }
    }
}
