using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("restaurant")]
public partial class Restaurant
{
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

    [ForeignKey("MenuId")]
    [InverseProperty("Restaurant")]
    public virtual Menu Menu { get; set; }
}