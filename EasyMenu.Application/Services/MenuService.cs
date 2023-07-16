using EasyMenu.Application.Contracts.Request.Menu;
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
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        public async Task<ResultData> PostAsync(MenuPostRequest menu)
        {
            var entity = new MenuEntity(menu);
            return Utils.SuccessData(await _menuRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(MenuPutRequest menu)
        {
            var entity = new MenuEntity(menu);
            return Utils.SuccessData(await _menuRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            return Utils.SuccessData(await _menuRepository.DeleteAsync(id));
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            return Utils.SuccessData(await _menuRepository.GetByIdAsync(id));
        }

        public async Task<ResultData> GetByFilterAsync(string filter)
        {
            return Utils.SuccessData(await _menuRepository.GetByFilterAsync(filter));
        }
    }
}
