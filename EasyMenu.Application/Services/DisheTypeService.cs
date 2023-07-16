using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Contracts.Request.DishesType;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Validators.DisheType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Services
{
    public class DisheTypeService
    {
        private readonly DisheTypeRepository _disheTypeRepository;

        public DisheTypeService(DisheTypeRepository dishesTypeRepository)
        {
            this._disheTypeRepository = dishesTypeRepository;
        }

        public async Task<ResultData> PostAsync(DisheTypePostRequest dishesType)
        {
            var validator = new DisheTypePostRequestValidator();
            var validationResult = validator.Validate(dishesType);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new DisheTypeEntity(dishesType);
            return Utils.SuccessData(await _disheTypeRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(DisheTypePutRequest dishesType)
        {
            var validator = new DisheTypePutRequestValidator();
            var validationResult = validator.Validate(dishesType);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new DisheTypeEntity(dishesType);
            return Utils.SuccessData(await _disheTypeRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            var entity = await _disheTypeRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.DisheType_Delete_BadRequest_DisheType_Does_Not_Exists.ToString());

            return Utils.SuccessData(await _disheTypeRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var entity = await _disheTypeRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.DisheType_GetById_BadRequest_DisheType_Does_Not_Exists.ToString());

            return Utils.SuccessData(entity);
        }

        public async Task<ResultData> GetAllAsync()
        {
            return Utils.SuccessData(await _disheTypeRepository.GetAllAsync());
        }
    }
}
