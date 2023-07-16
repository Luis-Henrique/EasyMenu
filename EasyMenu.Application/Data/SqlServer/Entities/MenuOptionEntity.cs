using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Application.Contracts.Request.MenuOption;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("menuOption")]
public class MenuOptionEntity
{
    public MenuOptionEntity(MenuOptionPostRequest menuOption)
    {
        this.Id = Guid.NewGuid();
        this.DisheId = menuOption.DisheId;
        this.MenuId = menuOption.MenuId;
    }

    public MenuOptionEntity(MenuOptionPutRequest menuOption)
    {
        this.Id = menuOption.Id;
        this.DisheId = menuOption.DisheId;
        this.MenuId = menuOption.MenuId;
    }

    public MenuOptionEntity()
    {
       
    }

    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("menuId")]
    public Guid MenuId { get; set; }

    [Column("disheId")]
    public Guid DisheId { get; set; }
}