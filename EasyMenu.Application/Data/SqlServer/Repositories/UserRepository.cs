using Dapper;
using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Data.MySql.Entities;
using EasyMenu.Application.Data.SqlServer;
using EasyMenu.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using static Dapper.SqlMapper;

namespace EasyMenu.Application.Data.MySql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext ctt)
        {
            _context = ctt;
        }

        public async Task<DefaultResponse> CreateUser(UserEntity entity) 
        {
            _context.User.Add(entity);
            var result = await this.SaveAllAsync();

            if (result == true)
               return new DefaultResponse(entity.Id.ToString(), "Conta criada com sucesso",false);

            return new DefaultResponse("", "Erro ao tentar criar uma conta", true);
        }

        public async Task<DefaultResponse> UpdateUser(UserEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await this.SaveAllAsync();

            if (result == true)
               return new DefaultResponse(entity.Id.ToString(), "Senha de usuário alterada com sucesso", false);

            return new DefaultResponse(entity.Id.ToString(), "Erro ao tentar alterar senha de um usuário", true);
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            return await _context.User.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> GetUserByUserNameAndEmail(string username, string email)
        {
            return await _context.User.Where(x => x.Email == email).Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> GetUserByCredentialsAsync(string email, string password)
        {
            return await _context.User.Where(x => x.Email == email).Where(x => x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
