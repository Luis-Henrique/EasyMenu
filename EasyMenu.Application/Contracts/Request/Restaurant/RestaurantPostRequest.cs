﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Request.Restaurant
{
    public class RestaurantPostRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string MenuId { get; set; }
    }
}
