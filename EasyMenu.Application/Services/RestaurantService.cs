using EasyMenu.Application.Contracts.Request.Restaurant;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Validators.Menu;
using EasyMenu.Application.Validators.Restaurant;
using EasyRestaurant.Application.Data.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly MenuService _menuService;

        public RestaurantService(RestaurantRepository restaurantRepository, MenuService menuService)
        {
            this._restaurantRepository = restaurantRepository;
            _menuService = menuService;
        }

        public async Task<ResultData> PostAsync(RestaurantPostRequest restaurant)
        {
            var validator = new RestaurantPostRequestValidator();
            var validationResult = validator.Validate(restaurant);

            var exists = await _menuService.GetByIdAsync(restaurant.MenuId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.Restaurant_Post_BadRequest_MenuId_Does_Not_Exists.ToString());

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new RestaurantEntity(restaurant);
            return Utils.SuccessData(await _restaurantRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(RestaurantPutRequest restaurant)
        {
            var validator = new RestaurantPutRequestValidator();
            var validationResult = validator.Validate(restaurant);

            var exists = await _menuService.GetByIdAsync(restaurant.MenuId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.Restaurant_Put_BadRequest_MenuId_Does_Not_Exists.ToString());

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new RestaurantEntity(restaurant);
            return Utils.SuccessData(await _restaurantRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            var entity = await _restaurantRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.Restaurant_Delete_BadRequest_Restaurant_Does_Not_Exists.ToString());

            return Utils.SuccessData(await _restaurantRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var entity = await _restaurantRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.Restaurant_GetById_BadRequest_Restaurant_Does_Not_Exists.ToString());

            return Utils.SuccessData(await _restaurantRepository.GetByIdAsync(id));
        }

        public async Task<ResultData> GetAllAsync()
        {
            return Utils.SuccessData(await _restaurantRepository.GetAllAsync());
        }
    }
}
