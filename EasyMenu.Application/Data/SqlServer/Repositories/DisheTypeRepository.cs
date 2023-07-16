using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Entities;
using EasyMenu.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EasyMenu.Application.Data.SqlServer.Repositories
{
    public class DisheTypeRepository : IDisheTypeRepository
    {
        private readonly SqlServerContext _context;

        public DisheTypeRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateAsync(DisheTypeEntity entity)
        {
            _context.DisheType.Add(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
               return new DefaultResponse(entity.Id.ToString(), "Tipo de prato criado com sucesso", false);

            return new DefaultResponse("", "Erro ao tentar criar um tipo de prato", true);
        }

        public async Task<DefaultResponse> UpdateAsync(DisheTypeEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Tipo de prato alterado com sucesso", false);
            
            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar alterar o tipo de prato", true);
        }

        public async Task<DefaultResponse> DeleteAsync(Guid id)
        {
            DisheTypeEntity entity = new DisheTypeEntity() { Id = id };
            _context.DisheType.Attach(entity);
            _context.DisheType.Remove(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
                return new DefaultResponse(entity.Id.ToString(), "Tipo de prato excluido com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar excluir o tipo de prato", true);
        }

        public async Task<DisheTypeEntity> GetByIdAsync(Guid id)
        {
            return await _context.DisheType.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DisheTypeEntity>> GetAllAsync()
        {
            return await _context.DisheType.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
