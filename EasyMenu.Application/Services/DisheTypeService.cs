using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Contracts.Request.DishesType;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Services
{
    public class DisheTypeService
    {
        private readonly IDisheTypeRepository _disheTypeRepository;

        public DisheTypeService(IDisheTypeRepository dishesTypeRepository)
        {
            this._disheTypeRepository = dishesTypeRepository;
        }

        public async Task<ResultData> PostAsync(DisheTypePostRequest dishesType)
        {
            var entity = new DisheTypeEntity(dishesType);
            return Utils.SuccessData(await _disheTypeRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(DisheTypePutRequest dishesType)
        {
            var entity = new DisheTypeEntity(dishesType);
            return Utils.SuccessData(await _disheTypeRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            return Utils.SuccessData(await _disheTypeRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            return Utils.SuccessData(await _disheTypeRepository.GetByIdAsync(id));
        }

        public async Task<ResultData> GetByFilterAsync(string filter)
        {
            return Utils.SuccessData(await _disheTypeRepository.GetByFilterAsync(filter));
        }
    }
}
