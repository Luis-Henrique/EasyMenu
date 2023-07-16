using EasyMenu.Application.Contracts.Request.MenuOption;
using EasyMenu.Application.Contracts.Request.Restaurant;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Validators.Restaurant
{
    public class RestaurantPostRequestValidator : AbstractValidator<RestaurantPostRequest>
    {
        public RestaurantPostRequestValidator() 
        {
            RuleFor(contract => contract.Name)
                  .Must(_name => !string.IsNullOrEmpty(_name))
                  .WithMessage(EasyMenuErrors.Restaurant_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Address)
                  .Must(_address => !string.IsNullOrEmpty(_address))
                  .WithMessage(EasyMenuErrors.Restaurant_Post_BadRequest_Address_Cannot_Be_Null_Or_Empty.Description());
        }
    }
}
