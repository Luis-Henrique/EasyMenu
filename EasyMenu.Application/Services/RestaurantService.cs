using EasyMenu.Application.Contracts.Request.Restaurant;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Helpers;
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

        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }

        public async Task<ResultData> PostAsync(RestaurantPostRequest restaurant)
        {
            var entity = new RestaurantEntity(restaurant);
            return Utils.SuccessData(await _restaurantRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(RestaurantPutRequest restaurant)
        {
            var entity = new RestaurantEntity(restaurant);
            return Utils.SuccessData(await _restaurantRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            return Utils.SuccessData(await _restaurantRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            return Utils.SuccessData(await _restaurantRepository.GetByIdAsync(id));
        }

        public async Task<ResultData> GetByFilterAsync(string filter)
        {
            return Utils.SuccessData(await _restaurantRepository.GetByFilterAsync(filter));
        }
    }
}
