using EasyMenu.Application.Contracts.Response;
using EasyMenu.Application.Data.MySql.Entities;
using EasyMenu.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<DefaultResponse> CreateUser(UserEntity entity);

        Task<DefaultResponse> UpdateUser(UserEntity entity);

        Task<UserEntity> GetUserByEmail(string email);

        Task<UserEntity> GetUserByUserNameAndEmail(string username, string email);

        Task<UserEntity> GetUserByCredentialsAsync(string email, string password);

        Task<bool> SaveAllAsync();
    }
}


