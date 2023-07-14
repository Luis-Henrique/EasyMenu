using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("dishes")]
public partial class Dishes
{
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
    public byte Portion { get; set; }

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

    [ForeignKey("DisheTypeId")]
    [InverseProperty("Dishes")]
    public virtual DisheType DisheType { get; set; }

    [InverseProperty("Dishe")]
    public virtual ICollection<MenuOption> MenuOption { get; set; } = new List<MenuOption>();
}