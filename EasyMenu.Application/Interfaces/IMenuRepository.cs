using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Interfaces
{
    public interface IMenuRepository
    {
        Task<DefaultResponse> CreateAsync(MenuEntity entity);

        Task<DefaultResponse> UpdateAsync(MenuEntity entity);

        Task<DefaultResponse> DeleteAsync(Guid id);

        Task<MenuEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<MenuEntity>> GetAllAsync();

        Task<bool> SaveAllAsync();
    }
}
