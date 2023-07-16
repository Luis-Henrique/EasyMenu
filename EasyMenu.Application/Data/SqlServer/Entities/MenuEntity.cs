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
    public MenuEntity(MenuPostRequest menu)
    {
        this.Id = Guid.NewGuid();
        this.Title = menu.Title;
        this.Description = menu.Description;
        this.CreatedDate = DateTime.Now;
    }

    public MenuEntity(MenuPutRequest menu)
    {
        this.Id = menu.Id;
        this.Title = menu.Title;
        this.Description = menu.Description;
        this.UpdatedDate = DateTime.Now;
        this.CreatedDate = DateTime.ParseExact(menu.CreatedDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
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
}