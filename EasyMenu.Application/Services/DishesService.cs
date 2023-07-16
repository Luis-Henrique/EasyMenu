using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Validators.Dishes;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace EasyMenu.Application.Services
{
    public class DishesService
    {
        private readonly DishesRepository _dishesRepository;
        private readonly DisheTypeService _disheTypeService;

        public DishesService(DishesRepository dishesRepository, DisheTypeService disheTypeService)
        {
            this._dishesRepository = dishesRepository;
            this._disheTypeService = disheTypeService;
        }

        public async Task<ResultData> PostAsync(DishesPostRequest dishes)
        {
            var validator = new DishesPostRequestValidator();
            var validationResult = validator.Validate(dishes);

            var exists = await _disheTypeService.GetByIdAsync(dishes.DisheTypeId);

            if(exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.Dishes_Post_BadRequest_DisheTypeId_Does_Not_Exists.ToString());

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new DishesEntity(dishes);
            return Utils.SuccessData(await _dishesRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(DishesPutRequest dishes)
        {
            var validator = new DishesPutRequestValidator();
            var validationResult = validator.Validate(dishes);

            var exists = await _disheTypeService.GetByIdAsync(dishes.DisheTypeId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.Dishes_Put_BadRequest_DisheTypeId_Does_Not_Exists.ToString());

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new DishesEntity(dishes);
            return Utils.SuccessData(await _dishesRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            var entity = await _dishesRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.Dishes_Delete_BadRequest_Dishes_Does_Not_Exists.ToString());

            return Utils.SuccessData(await _dishesRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var entity = await _dishesRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.Dishes_GetById_BadRequest_Dishes_Does_Not_Exists.ToString());

            return Utils.SuccessData(entity);
        }

        public async Task<ResultData> GetByFilterAsync(string filter)
        {
            return Utils.SuccessData(await _dishesRepository.GetByFilterAsync(filter));
        }
    }
}
