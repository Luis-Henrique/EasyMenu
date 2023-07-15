using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Application.Contracts.Request.Menu;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("menu")]
public class MenuEntity
{
    public MenuEntity(MenuPostRequest document)
    {
        this.Id = Guid.NewGuid();
        this.Title = document.Title;
        this.Description = document.Description;
        this.CreatedDate = DateTime.Now;
    }

    public MenuEntity(MenuPutRequest document)
    {
        this.Title = document.Title;
        this.Description = document.Description;
        this.UpdatedDate = DateTime.Now;
    }

    public MenuEntity()
    {

    }

    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("title")]
    [StringLength(50)]
    [Unicode(false)]
    public string Title { get; set; }

    [Column("description")]
    [StringLength(200)]
    [Unicode(false)]
    public string Description { get; set; }

    [Column("createdDate", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updatedDate", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [InverseProperty("Menu")]
    public virtual ICollection<MenuOptionEntity> MenuOption { get; set; } = new List<MenuOptionEntity>();

    [InverseProperty("Menu")]
    public virtual ICollection<RestaurantEntity> Restaurant { get; set; } = new List<RestaurantEntity>();
}