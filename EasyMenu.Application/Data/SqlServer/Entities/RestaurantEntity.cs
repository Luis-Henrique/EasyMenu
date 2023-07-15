using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Application.Contracts.Request.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("restaurant")]
public partial class RestaurantEntity
{
    public RestaurantEntity(RestaurantPostRequest document)
    {
        this.Id = Guid.NewGuid();
        this.Name = document.Name;
        this.Address = document.Address;
        this.MenuId = document.MenuId;
        this.CreatedDate = DateTime.Now;
    }

    public RestaurantEntity(RestaurantPutRequest document)
    {
        this.Name = document.Name;
        this.Address = document.Address;
        this.MenuId = document.MenuId;
        this.UpdatedDate = DateTime.Now;
    }

    public RestaurantEntity()
    {
       
    }

    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }

    [Column("address")]
    [StringLength(200)]
    [Unicode(false)]
    public string Address { get; set; }

    [Column("menuId")]
    public string MenuId { get; set; }

    [Column("createdDate", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updatedDate", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [ForeignKey("MenuId")]
    [InverseProperty("Restaurant")]
    public virtual MenuEntity Menu { get; set; }
}