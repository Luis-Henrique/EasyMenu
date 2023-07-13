using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Request.DishesType
{
    public class MenuOptionPutRequest
    {
        public Guid Id { get; set; }

        public string MenuId { get; set; }

        public string DisheId { get; set; }
    }
}
