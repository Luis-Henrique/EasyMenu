using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<DefaultResponse> CreateAsync(RestaurantEntity entity);

        Task<DefaultResponse> UpdateAsync(RestaurantEntity entity);

        Task<DefaultResponse> DeleteAsync(Guid id);

        Task<RestaurantEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<RestaurantEntity>> GetAllAsync();

        Task<bool> SaveAllAsync();
    }
}
