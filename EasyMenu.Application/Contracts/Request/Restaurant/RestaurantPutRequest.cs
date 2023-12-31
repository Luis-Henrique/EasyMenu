﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Request.Restaurant
{
    public class RestaurantPutRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Guid MenuId { get; set; }

        public string CreatedDate { get; set; }
    }
}
