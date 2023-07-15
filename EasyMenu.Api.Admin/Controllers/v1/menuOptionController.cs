using EasyMenu.Application.Contracts.Request.Menu;
using EasyMenu.Application.Contracts.Request.MenuOption;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MenuOptionController
    {
        private readonly MenuOptionService _menuOptionService;
        public MenuOptionController(MenuOptionService repository)
        {
            this._menuOptionService = repository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] MenuOptionPostRequest request)
        {
            var response = await _menuOptionService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] MenuOptionPutRequest request)
        {
            var response = await _menuOptionService.PutAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _menuOptionService.GetByIdAsync(id);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _menuOptionService.DeleteAsync(id);
            return Utils.Convert(response);
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByfilter([FromQuery] string request)
        {
            throw new NotImplementedException();
        }
    }
}
