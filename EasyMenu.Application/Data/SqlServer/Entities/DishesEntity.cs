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
    public DishesEntity(DishesPostRequest document)
    {
        this.Id = Guid.NewGuid();
        this.Title = document.Title;
        this.Description = document.Description;
        this.Price = document.Price;
        this.Portion = document.Portion;
        this.Promotion = document.Promotion;
        this.PromotionPrice = document.PromotionPrice;
        this.DisheTypeId = document.DisheTypeId;
        this.CreatedDate = DateTime.Now;
    }

    public DishesEntity(DishesPutRequest document)
    {
        this.Title = document.Title;
        this.Description = document.Description;
        this.Price = document.Price;
        this.Portion = document.Portion;
        this.Promotion = document.Promotion;
        this.PromotionPrice = document.PromotionPrice;
        this.DisheTypeId = document.DisheTypeId;
        this.UpdatedDate = DateTime.Now;
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
    public string DisheTypeId { get; set; }

    [Column("createdDate", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updatedDate", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [ForeignKey("DisheTypeId")]
    [InverseProperty("Dishes")]
    public virtual DisheTypeEntity DisheType { get; set; }

    [InverseProperty("Dishe")]
    public virtual ICollection<MenuOptionEntity> MenuOption { get; set; } = new List<MenuOptionEntity>();
}