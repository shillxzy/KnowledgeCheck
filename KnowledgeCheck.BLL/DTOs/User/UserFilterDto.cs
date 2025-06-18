using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.User
{
    public class UserFilterDto
    {
        public string? Role { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }


        public string? SortBy { get; set; }     
        public string? SortOrder { get; set; }
    }
}
