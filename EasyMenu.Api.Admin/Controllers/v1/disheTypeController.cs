using EasyMenu.Application.Contracts.Request.DishesType;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Api.Admin.Controllers.v1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DisheTypeController
    {
        private readonly DisheTypeService _disheTypeService;
        public DisheTypeController(DisheTypeService repository)
        {
            this._disheTypeService = repository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] DisheTypePostRequest request)
        {
            var response = await _disheTypeService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] DisheTypePutRequest request)
        {
            var response = await _disheTypeService.PutAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _disheTypeService.GetByIdAsync(id);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _disheTypeService.DeleteAsync(id);
            return Utils.Convert(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _disheTypeService.GetAllAsync();
            return Utils.Convert(response);
        }
    }
}
