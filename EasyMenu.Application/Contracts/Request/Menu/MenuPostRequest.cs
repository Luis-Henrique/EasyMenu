using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Request.Menu
{
    public class MenuPostRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
