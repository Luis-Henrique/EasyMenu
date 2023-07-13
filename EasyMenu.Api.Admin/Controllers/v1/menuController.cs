using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class menuController
    {
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] string request)
        {
            return null;
        }
    }
}