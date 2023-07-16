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
    public class MenuRepository : IMenuRepository
    {
        private readonly SqlServerContext _context;

        public MenuRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateAsync(MenuEntity entity)
        {
            _context.Menu.Add(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Cardápio criado com sucesso", false);

            return new DefaultResponse("", "Erro ao tentar criar um cardápio ", true);
        }

        public async Task<DefaultResponse> UpdateAsync(MenuEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Cardápio alterado com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar alterar o cardápio", true);
        }

        public async Task<DefaultResponse> DeleteAsync(Guid id)
        {
            MenuEntity entity = new MenuEntity() { Id = id };
            _context.Menu.Attach(entity);
            _context.Menu.Remove(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Cardápio excluido com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar excluir o cardápio", true);
        }

        public async Task<MenuEntity> GetByIdAsync(Guid id)
        {
            return await _context.Menu.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MenuEntity>> GetAllAsync()
        {
            return await _context.Menu.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
