using EasyMenu.Application.Contracts.Request.MenuOption;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Validators.DisheType;
using EasyMenu.Application.Validators.MenuOption;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Services
{
    public class MenuOptionService
    {
        private readonly MenuOptionRepository _menuOptionRepository;
        private readonly MenuService _menuService;
        private readonly DishesService _dishesService;

        public MenuOptionService(MenuOptionRepository menuOptionRepository, MenuService menuService, DishesService dishesService)
        {
            this._menuOptionRepository = menuOptionRepository;
            this._menuService = menuService;
            this._dishesService = dishesService;
        }

        public async Task<ResultData> PostAsync(MenuOptionPostRequest menuOption)
        {
            var exists = await _menuService.GetByIdAsync(menuOption.MenuId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.MenuOption_Post_BadRequest_MenuId_Does_Not_Exists.ToString());

            exists = await _dishesService.GetByIdAsync(menuOption.DisheId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.MenuOption_Post_BadRequest_DisheId_Does_Not_Exists.ToString());

            var entity = new MenuOptionEntity(menuOption);
            return Utils.SuccessData(await _menuOptionRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(MenuOptionPutRequest menuOption)
        {
            var exists = await _menuService.GetByIdAsync(menuOption.MenuId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.MenuOption_Put_BadRequest_MenuId_Does_Not_Exists.ToString());

            exists = await _dishesService.GetByIdAsync(menuOption.DisheId);

            if (exists.Success == false)
                return Utils.ErrorData(EasyMenuErrors.MenuOption_Put_BadRequest_DisheId_Does_Not_Exists.ToString());

            var entity = new MenuOptionEntity(menuOption);
            return Utils.SuccessData(await _menuOptionRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            var entity = await _menuOptionRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.MenuOption_Delete_BadRequest_MenuOption_Does_Not_Exists.ToString());

            return Utils.SuccessData(await _menuOptionRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var entity = await _menuOptionRepository.GetByIdAsync(id);
            if (entity == null)
                return Utils.ErrorData(EasyMenuErrors.MenuOption_GetById_BadRequest_MenuOption_Does_Not_Exists.ToString());

            return Utils.SuccessData(entity);
        }

        public async Task<ResultData> GetAllAsync()
        {
            return Utils.SuccessData(await _menuOptionRepository.GetAllAsync());
        }
    }
}
