using EasyMenu.Application.Contracts.Request.Dishes;
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
    public class DishesService
    {
        private readonly DishesRepository _dishesRepository;

        public DishesService(DishesRepository dishesRepository)
        {
            this._dishesRepository = dishesRepository;
        }

        public async Task<ResultData> PostAsync(DishesPostRequest dishes)
        {
            var entity = new DishesEntity(dishes);
            return Utils.SuccessData(await _dishesRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(DishesPutRequest dishes)
        {
            var entity = new DishesEntity(dishes);
            return Utils.SuccessData(await _dishesRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            return Utils.SuccessData(await _dishesRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            return Utils.SuccessData(await _dishesRepository.GetByIdAsync(id));
        }

        public async Task<ResultData> GetByFilterAsync(string filter)
        {
            return Utils.SuccessData(await _dishesRepository.GetByFilterAsync(filter));
        }
    }
}
