using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Enums;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("dishes")]
public class DishesEntity
{
    public DishesEntity(DishesPostRequest dishes)
    {
        this.Id = Guid.NewGuid();
        this.Title = dishes.Title;
        this.Description = dishes.Description;
        this.Price = dishes.Price;
        this.Portion = dishes.Portion;
        this.Promotion = dishes.Promotion;
        this.PromotionPrice = dishes.PromotionPrice;
        this.DisheTypeId = dishes.DisheTypeId;
        this.CreatedDate = DateTime.Now;
    }

    public DishesEntity(DishesPutRequest dishes)
    {
        this.Id = dishes.Id;
        this.Title = dishes.Title;
        this.Description = dishes.Description;
        this.Price = dishes.Price;
        this.Portion = dishes.Portion;
        this.Promotion = dishes.Promotion;
        this.PromotionPrice = dishes.PromotionPrice;
        this.DisheTypeId = dishes.DisheTypeId;
        this.UpdatedDate = DateTime.Now;
        this.CreatedDate = DateTime.ParseExact(dishes.CreatedDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
    }

    public DishesEntity()
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

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("portion")]
    public Portion Portion { get; set; }

    [Column("promotion")]
    public bool? Promotion { get; set; }

    [Column("promotionPrice", TypeName = "decimal(10, 2)")]
    public decimal? PromotionPrice { get; set; }

    [Column("disheTypeId")]
    public Guid DisheTypeId { get; set; }

    [Column("createdDate", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updatedDate", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}