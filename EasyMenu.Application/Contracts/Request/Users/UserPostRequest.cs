﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMenu.Application.Contracts.Request.Users
{
    public class UserPostRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
