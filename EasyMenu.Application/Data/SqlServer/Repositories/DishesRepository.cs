using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Data.SqlServer.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly SqlServerContext _context;

        public DishesRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateAsync(DishesEntity entity)
        {
            _context.Dishes.Add(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Prato criado com sucesso", false);

            return new DefaultResponse("", "Erro ao tentar criar um prato", true);
        }

        public async Task<DefaultResponse> UpdateAsync(DishesEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Prato alterado com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar alterar o prato", true);
        }

        public async Task<DefaultResponse> DeleteAsync(Guid id)
        {
            DishesEntity entity = new DishesEntity() { Id = id };
            _context.Dishes.Attach(entity);
            _context.Dishes.Remove(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Prato excluido com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar excluir o tipo de Prato", true);
        }

        public async Task<DishesEntity> GetByIdAsync(Guid id)
        {  
           return await _context.Dishes.FindAsync(id);
        }

        public async Task<IEnumerable<DishesEntity>> GetAllAsync()
        {
           return await _context.Dishes.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
