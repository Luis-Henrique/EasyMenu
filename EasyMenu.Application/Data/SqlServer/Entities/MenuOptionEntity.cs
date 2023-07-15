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
    public MenuOptionEntity(MenuOptionPostRequest document)
    {
        this.Id = Guid.NewGuid();
        this.DisheId = document.DisheId;
        this.MenuId = document.MenuId;
    }

    public MenuOptionEntity(MenuOptionPutRequest document)
    {
        this.DisheId = document.DisheId;
        this.MenuId = document.MenuId;
    }

    public MenuOptionEntity()
    {
       
    }

    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("menuId")]
    public string MenuId { get; set; }

    [Column("disheId")]
    public string DisheId { get; set; }

    [ForeignKey("DisheId")]
    [InverseProperty("MenuOption")]
    public virtual DishesEntity Dishe { get; set; }

    [ForeignKey("MenuId")]
    [InverseProperty("MenuOption")]
    public virtual MenuEntity Menu { get; set; }
}