using EasyMenu.Application.Contracts.Request.Menu;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Validators.Menu;
using EasyMenu.Application.Validators.MenuOption;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Services
{
    public class MenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService(MenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        public async Task<ResultData> PostAsync(MenuPostRequest menu)
        {
            var validator = new MenuPostRequestValidator();
            var validationResult = validator.Validate(menu);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new MenuEntity(menu);
            return Utils.SuccessData(await _menuRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(MenuPutRequest menu)
        {
            var validator = new MenuPutRequestValidator();
            var validationResult = validator.Validate(menu);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorList());

            var entity = new MenuEntity(menu);
            return Utils.SuccessData(await _menuRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            var entity = await _menuRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.Menu_Delete_BadRequest_Menu_Does_Not_Exists.ToString());

            return Utils.SuccessData(await _menuRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var entity = await _menuRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.Menu_GetById_BadRequest_Menu_Does_Not_Exists.ToString());

            return Utils.SuccessData(entity);
        }

        public async Task<ResultData> GetAllAsync()
        {
            return Utils.SuccessData(await _menuRepository.GetAllAsync());
        }
    }
}
