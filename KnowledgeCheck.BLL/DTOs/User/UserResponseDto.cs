using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.User
{
    public class UserResponseDto : UserDto
    {
        public bool IsBlocked { get; set; }
    }
}
