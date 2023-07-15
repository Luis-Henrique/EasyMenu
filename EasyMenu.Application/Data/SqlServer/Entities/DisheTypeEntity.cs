using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Application.Contracts.Request.Dishes;
using EasyMenu.Application.Contracts.Request.DishesType;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("disheType")]
public class DisheTypeEntity
{
    public DisheTypeEntity(DisheTypePostRequest document)
    {
        this.Id = Guid.NewGuid();
        this.Title = document.Title;
        this.Description = document.Description;
        this.CreatedDate = DateTime.Now;
    }

    public DisheTypeEntity(DisheTypePutRequest document)
    {
        this.Title = document.Title;
        this.Description = document.Description;
        this.UpdatedDate = DateTime.Now;
    }

    public DisheTypeEntity()
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

    [InverseProperty("DisheType")]
    public virtual ICollection<DishesEntity> Dishes { get; set; } = new List<DishesEntity>();
}