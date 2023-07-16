using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Application.Contracts.Request.DishesType;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("disheType")]
public class DisheTypeEntity
{
    public DisheTypeEntity(DisheTypePostRequest disheType)
    {
        this.Id = Guid.NewGuid();
        this.Title = disheType.Title;
        this.Description = disheType.Description;
        this.CreatedDate = DateTime.Now;
    }

    public DisheTypeEntity(DisheTypePutRequest disheType)
    {
        this.Id = disheType.Id;
        this.Title = disheType.Title;
        this.Description = disheType.Description;
        this.UpdatedDate = DateTime.Now;
        this.CreatedDate = DateTime.ParseExact(disheType.CreatedDate, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
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
}