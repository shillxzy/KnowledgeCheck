﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.DTOs.User
{
    public class UserUpdateDto
    {
        public string? UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
    }
}
