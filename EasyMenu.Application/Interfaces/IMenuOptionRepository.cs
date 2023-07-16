using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Interfaces
{
    public interface IMenuOptionRepository
    {
        Task<DefaultResponse> CreateAsync(MenuOptionEntity entity);

        Task<DefaultResponse> UpdateAsync(MenuOptionEntity entity);

        Task<DefaultResponse> DeleteAsync(Guid id);

        Task<MenuOptionEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<MenuOptionEntity>> GetAllAsync();

        Task<bool> SaveAllAsync();
    }
}
