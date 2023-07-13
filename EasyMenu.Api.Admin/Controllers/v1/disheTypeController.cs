using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DisheTypeController
    {
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] string request)
        {
            return null;
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] string request)
        {
            return null;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return null;
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            return null;
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByfilter([FromQuery] string request)
        {
            return null;
        }
    }
}
