using EasyMenu.Application.Contracts.Request.Restaurant;
using EasyMenu.Application.Data.SqlServer.Repositories;
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
    public class RestaurantPutRequestValidator : AbstractValidator<RestaurantPutRequest>
    {
        public RestaurantPutRequestValidator() 
        {
            RuleFor(contract => contract.Name)
                      .Must(_name => !string.IsNullOrEmpty(_name))
                      .WithMessage(EasyMenuErrors.Restaurant_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Address)
                  .Must(_address => !string.IsNullOrEmpty(_address))
                  .WithMessage(EasyMenuErrors.Restaurant_Put_BadRequest_Address_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.CreatedDate)
                .NotEmpty()
                .WithMessage(EasyMenuErrors.Restaurant_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty.Description());
        }
    }
}
