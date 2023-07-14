using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("menuOption")]
public partial class MenuOption
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("menuId")]
    public Guid MenuId { get; set; }

    [Column("disheId")]
    public Guid DisheId { get; set; }

    [ForeignKey("DisheId")]
    [InverseProperty("MenuOption")]
    public virtual Dishes Dishe { get; set; }

    [ForeignKey("MenuId")]
    [InverseProperty("MenuOption")]
    public virtual Menu Menu { get; set; }
}