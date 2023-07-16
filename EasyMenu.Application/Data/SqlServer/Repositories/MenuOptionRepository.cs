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
    public class MenuOptionRepository : IMenuOptionRepository
    {
        private readonly SqlServerContext _context;

        public MenuOptionRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateAsync(MenuOptionEntity entity)
        {
            _context.MenuOption.Add(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Opção do cardápio criada com sucesso", false);

            return new DefaultResponse("", "Erro ao tentar criar uma opção do cardápio ", true);
        }

        public async Task<DefaultResponse> UpdateAsync(MenuOptionEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Opção do cardápio alterada com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar alterar a opção do cardápio", true);
        }

        public async Task<DefaultResponse> DeleteAsync(Guid id)
        {
            MenuOptionEntity entity = new MenuOptionEntity() { Id = id };
            _context.MenuOption.Attach(entity);
            _context.MenuOption.Remove(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Opção do cardápio excluida com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar excluir a opção do cardápio", true);
        }

        public async Task<MenuOptionEntity> GetByIdAsync(Guid id)
        {
            return await _context.MenuOption.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MenuOptionEntity>> GetAllAsync()
        {
            return await _context.MenuOption.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
