using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Contracts.Response
{
    public class DefaultResponse
    {
        public DefaultResponse(string id, string message, bool hasErrors)
        {
            this.Id = id;
            this.Message = message;
            this.HasErrors = hasErrors;
        }

        public string Id { get; set; }
        public string Message { get; set; }
        public bool HasErrors { get; set; }
    }
}
