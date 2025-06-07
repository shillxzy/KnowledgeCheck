﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Entities
{
    public class User : IdentityUser
    {
       public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; }
    }
}
