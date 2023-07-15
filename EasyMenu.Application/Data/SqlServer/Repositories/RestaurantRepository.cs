using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Data.SqlServer.Repositories
{
    public class RestaurantRepository
    {
        private readonly SqlServerContext _context;

        public RestaurantRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateAsync(RestaurantEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DefaultResponse> UpdateAsync(RestaurantEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DefaultResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RestaurantEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetByFilterAsync(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
