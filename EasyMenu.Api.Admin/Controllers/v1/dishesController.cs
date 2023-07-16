using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DishesController
    {
        private readonly DishesService _dishesService;
        public DishesController(DishesService repository)
        {
            this._dishesService = repository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] DishesPostRequest request)
        {
            var response = await _dishesService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] DishesPutRequest request)
        {
            var response = await _dishesService.PutAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _dishesService.GetByIdAsync(id);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _dishesService.DeleteAsync(id);
            return Utils.Convert(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _dishesService.GetAllAsync();
            return Utils.Convert(response);
        }
    }
}
