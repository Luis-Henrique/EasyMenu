using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Request.MenuOption
{
    public class MenuOptionPutRequest
    {
        public Guid Id { get; set; }

        public Guid MenuId { get; set; }

        public Guid DisheId { get; set; }
    }
}
