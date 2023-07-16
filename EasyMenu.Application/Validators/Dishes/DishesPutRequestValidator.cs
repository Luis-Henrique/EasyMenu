using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Validators.Dishes
{
    public class DishesPutRequestValidator : AbstractValidator<DishesPutRequest>
    {
        public DishesPutRequestValidator() 
        {
            RuleFor(contract => contract.Title)
                     .Must(_title => !string.IsNullOrEmpty(_title))
                     .WithMessage(EasyMenuErrors.Dishes_Put_BadRequest_Title_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Description)
                  .Must(_description => !string.IsNullOrEmpty(_description))
                  .WithMessage(EasyMenuErrors.Dishes_Put_BadRequest_Description_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.Price).Must(p => p >= 0)
                 .WithMessage(EasyMenuErrors.Dishes_Put_BadRequest_Price_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.CreatedDate)
                .NotEmpty()
                .WithMessage(EasyMenuErrors.Dishes_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty.Description());

        }
    }
}
