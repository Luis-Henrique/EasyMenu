using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMenu.Application.Contracts.Request.Users
{
    public class UserPutRequest
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string CreatedDate { get; set; }
    }

}
