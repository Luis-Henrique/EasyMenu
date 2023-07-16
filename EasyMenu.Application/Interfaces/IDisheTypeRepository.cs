using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Interfaces
{
    public interface IDisheTypeRepository
    {
        Task<DefaultResponse> CreateAsync(DisheTypeEntity entity);

        Task<DefaultResponse> UpdateAsync(DisheTypeEntity entity);

        Task<DefaultResponse> DeleteAsync(Guid id);

        Task<DisheTypeEntity> GetByIdAsync(Guid id);

        Task<string> GetByFilterAsync(string filter);

        Task<bool> SaveAllAsync();
    }
}


