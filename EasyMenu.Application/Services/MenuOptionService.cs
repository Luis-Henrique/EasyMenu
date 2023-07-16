using EasyMenu.Application.Contracts.Request.MenuOption;
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
    public class MenuOptionService
    {
        private readonly IMenuOptionRepository _menuOptionRepository;

        public MenuOptionService(IMenuOptionRepository menuOptionRepository)
        {
            this._menuOptionRepository = menuOptionRepository;
        }

        public async Task<ResultData> PostAsync(MenuOptionPostRequest menuOption)
        {
            var entity = new MenuOptionEntity(menuOption);
            return Utils.SuccessData(await _menuOptionRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(MenuOptionPutRequest menuOption)
        {
            var entity = new MenuOptionEntity(menuOption);
            return Utils.SuccessData(await _menuOptionRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            return Utils.SuccessData(await _menuOptionRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            return Utils.SuccessData(await _menuOptionRepository.GetByIdAsync(id));
        }

        public async Task<ResultData> GetByFilterAsync(string filter)
        {
            return Utils.SuccessData(await _menuOptionRepository.GetByFilterAsync(filter));
        }
    }
}
