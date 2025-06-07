﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "User not found.") : base(message) { }
    }
}
