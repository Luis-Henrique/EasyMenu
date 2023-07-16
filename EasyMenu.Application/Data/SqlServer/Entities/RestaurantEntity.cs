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
    public RestaurantEntity(RestaurantPostRequest restaurant)
    {
        this.Id = Guid.NewGuid();
        this.Name = restaurant.Name;
        this.Address = restaurant.Address;
        this.MenuId = restaurant.MenuId;
        this.CreatedDate = DateTime.Now;
    }

    public RestaurantEntity(RestaurantPutRequest restaurant)
    {
        this.Id = restaurant.Id;
        this.Name = restaurant.Name;
        this.Address = restaurant.Address;
        this.MenuId = restaurant.MenuId;
        this.UpdatedDate = DateTime.Now;
        this.CreatedDate = DateTime.ParseExact(restaurant.CreatedDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
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
    public Guid MenuId { get; set; }

    [Column("createdDate", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updatedDate", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}