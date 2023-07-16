using EasyMenu.Application.Contracts.Request.Users;
using EasyMenu.Application.Data.MySql.Repositories;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using FluentValidation;

namespace EasyMenu.Application.Validators.User
{
    public class UserPostRequestValidator : AbstractValidator<UserPostRequest>
    {
        public UserPostRequestValidator(UserRepository userRepository) {
            RuleFor(contract => contract.UserName)
                    .Must(_name => !string.IsNullOrEmpty(_name))
                    .WithMessage(EasyMenuErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Email)
                    .Must(_email => !string.IsNullOrEmpty(_email))
                    .WithMessage(EasyMenuErrors.User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Password)
                    .Must(_pass => !string.IsNullOrEmpty(_pass))
                    .WithMessage(EasyMenuErrors.User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Email)
                    .Must(email =>
                    {
                        var userExists = userRepository.GetUserByEmail(email).Result;
                        return userExists == null;
                    })
                    .WithMessage(EasyMenuErrors.User_Post_BadRequest_Email_Cannot_Be_Duplicated.Description());
        }
    }
}

