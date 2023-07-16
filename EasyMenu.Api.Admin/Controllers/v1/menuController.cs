using EasyMenu.Application.Contracts.Request.Menu;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MenuController
    {
        private readonly MenuService _menuService;
        public MenuController(MenuService repository)
        {
            this._menuService = repository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] MenuPostRequest request)
        {
            var response = await _menuService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] MenuPutRequest request)
        {
            var response = await _menuService.PutAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _menuService.GetByIdAsync(id);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _menuService.DeleteAsync(id);
            return Utils.Convert(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var response = await _menuService.GetAllAsync();
            return Utils.Convert(response);
        }
    }
}