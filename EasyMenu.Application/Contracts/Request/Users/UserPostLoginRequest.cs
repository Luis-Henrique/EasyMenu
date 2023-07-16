using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMenu.Application.Contracts.Request.Users
{
    public class UserPostLoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
