using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Entities;

[Table("menu")]
public partial class Menu
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

    [Column("createdDate", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updatedDate", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [InverseProperty("Menu")]
    public virtual ICollection<MenuOption> MenuOption { get; set; } = new List<MenuOption>();

    [InverseProperty("Menu")]
    public virtual ICollection<Restaurant> Restaurant { get; set; } = new List<Restaurant>();
}