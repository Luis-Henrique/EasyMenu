using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Data.SqlServer;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyRestaurant.Application.Data.SqlServer.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly SqlServerContext _context;

        public RestaurantRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateAsync(RestaurantEntity entity)
        {
            _context.Restaurant.Add(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Restaurante criado com sucesso", false);

            return new DefaultResponse("", "Erro ao tentar criar uma opção do restaurante ", true);
        }

        public async Task<DefaultResponse> UpdateAsync(RestaurantEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Restaurante alterado com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar alterar o restaurante", true);
        }

        public async Task<DefaultResponse> DeleteAsync(Guid id)
        {
            RestaurantEntity entity = new RestaurantEntity() { Id = id };
            _context.Restaurant.Attach(entity);
            _context.Restaurant.Remove(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Restaurante excluido com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar excluir o restaurante", true);
        }

        public async Task<RestaurantEntity> GetByIdAsync(Guid id)
        {
            return await _context.Restaurant.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> GetByFilterAsync(string filter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

