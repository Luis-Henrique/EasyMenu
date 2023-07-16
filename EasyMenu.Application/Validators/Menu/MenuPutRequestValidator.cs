using EasyMenu.Application.Contracts.Request.DishesType;
using EasyMenu.Application.Contracts.Request.Menu;
using EasyMenu.Application.Errors;
using EasyMenu.Application.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMenu.Application.Validators.Menu
{
    public class MenuPutRequestValidator : AbstractValidator<MenuPutRequest>
    {
        public MenuPutRequestValidator()
        {
            RuleFor(contract => contract.Title)
                 .Must(_title => !string.IsNullOrEmpty(_title))
                 .WithMessage(EasyMenuErrors.Menu_Put_BadRequest_Title_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Description)
                  .Must(_description => !string.IsNullOrEmpty(_description))
                  .WithMessage(EasyMenuErrors.Menu_Put_BadRequest_Description_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.CreatedDate)
                .NotEmpty()
                .WithMessage(EasyMenuErrors.Menu_Put_BadRequest_CreatedDate_Cannot_Be_Null_Or_Empty.Description());

        }
    }
}
