﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMenu.Application.Contracts
{
    public class AccountResponse
    {
        public AccountResponse(){}
        public string Id { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
