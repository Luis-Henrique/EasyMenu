using EasyMenu.Application.Contracts;
using EasyMenu.Application.Contracts.Request.Users;
using EasyMenu.Application.Data.MySql.Entities;
using EasyMenu.Application.Data.MySql.Repositories;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Validators.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMenu.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<ResultData> PostAsync(UserPostRequest request)
        {
            var validator = new UserPostRequestValidator(_userRepository);
            var validatorResult = validator.Validate(request);

            if (!validatorResult.IsValid)
                return Utils.ErrorData(validatorResult.Errors.ToErrorList());

            var entity = new UserEntity(request);
            var response = await _userRepository.CreateUser(entity);
            Console.WriteLine("Sucesso" + DateTime.Now + "\r\n");
            return Utils.SuccessData(response);
        }

        public async Task<ResultData> PutAsync(UserPutRequest request)
        {
            var existUser = await _userRepository.GetUserByUserNameAndEmail(request.UserName, request.Email);

            if (existUser != null)
            {
                var entity = new UserEntity(request);
                var result = await _userRepository.UpdateUser(entity);

                if (!result.HasErrors) 
                   return Utils.SuccessData(result);

                return Utils.ErrorData(result);
            }
            return Utils.ErrorData(EasyMenuErrors.User_Put_BadRequest_User_Not_Found.Description());
        }

        public async Task<UserEntity> Authenticate(string user, string password)
        {
            var response = await _userRepository.GetUserByCredentialsAsync(user, password);
            return response;
        }


        public async Task<ResultData> PostLoginAsync(UserPostLoginRequest user)
        {
            var openData = user.Email + ":" + user.Password + ":" + Utils.GetDateExpired(10);
            var dataBytes = Utils.ToBase64Encode(openData);
            var getuser = await _userRepository.GetUserByCredentialsAsync(user.Email, user.Password);

            if (getuser != null)
            {
                var response = new AccountResponse
                {
                    Id = getuser.Id.ToString(),
                    Message = "Token successful",
                    Token = dataBytes
                };
                return Utils.SuccessData(response);
            }

            return Utils.ErrorData(new AccountResponse { Message = "Token Fail" });
        }

    }
}
