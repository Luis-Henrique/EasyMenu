using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Contracts.Request.DishesType;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Validators.DisheType
{
    public class DisheTypePostRequestValidator : AbstractValidator<DisheTypePostRequest>
    {
        public DisheTypePostRequestValidator()
        {
            RuleFor(contract => contract.Title)
                 .Must(_title => !string.IsNullOrEmpty(_title))
                 .WithMessage(EasyMenuErrors.DisheType_Post_BadRequest_Title_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Description)
                  .Must(_description => !string.IsNullOrEmpty(_description))
                  .WithMessage(EasyMenuErrors.DisheType_Post_BadRequest_Description_Cannot_Be_Null_Or_Empty.Description());
        }
    }
}
