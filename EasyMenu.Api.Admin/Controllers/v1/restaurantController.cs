using EasyMenu.Application.Contracts.Request.Menu;
using EasyMenu.Application.Contracts.Request.MenuOption;
using EasyMenu.Application.Contracts.Request.Restaurant;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RestaurantController
    {
        private readonly RestaurantService _restaurantService;
        public RestaurantController(RestaurantService repository)
        {
            this._restaurantService = repository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] RestaurantPostRequest request)
        {
            var response = await _restaurantService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] RestaurantPutRequest request)
        {
            var response = await _restaurantService.PutAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _restaurantService.GetByIdAsync(id);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _restaurantService.DeleteAsync(id);
            return Utils.Convert(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _restaurantService.GetAllAsync();
            return Utils.Convert(response);
        }
    }
}
