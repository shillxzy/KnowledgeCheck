using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
        public DateTime TakenAt { get; set; }

        public User User { get; set; } = null!;
        public Test Test { get; set; } = null!;
    }
}
