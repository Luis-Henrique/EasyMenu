using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Interfaces
{
    public interface IDishesRepository
    {
        Task<DefaultResponse> CreateAsync(DishesEntity entity);

        Task<DefaultResponse> UpdateAsync(DishesEntity entity);

        Task<DefaultResponse> DeleteAsync(Guid id);

        Task<DishesEntity> GetByIdAsync(Guid id);

        Task<string> GetByFilterAsync(string filter);

        Task<bool> SaveAllAsync();
    }
}
