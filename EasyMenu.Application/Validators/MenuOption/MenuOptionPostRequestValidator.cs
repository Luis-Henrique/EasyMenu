using EasyMenu.Application.Contracts.Request.MenuOption;
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

namespace EasyMenu.Application.Validators.MenuOption
{
    public class MenuOptionPostRequestValidator : AbstractValidator<MenuOptionPostRequest>
    {
        public MenuOptionPostRequestValidator() 
        {
            
        } 
    }
}
