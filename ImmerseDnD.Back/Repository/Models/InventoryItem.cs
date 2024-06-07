using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Repository.Models;

public partial class InventoryItem
{
    [Key]
    [Column("ID")]
    public Guid ItemId { get; set; }

    [Column("CharacterID")]
    public Guid CharacterId { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string ItemName { get; set; } = null!;

    [StringLength(256)]
    [Unicode(false)]
    public string ItemDescription { get; set; } = null!;

    [ForeignKey("CharacterId")]
    [InverseProperty("InventoryItems")]
    public virtual Character Character { get; set; } = null!;
}

public class InventoryItemDto
{
    public Guid ItemId { get; set; }
    public Guid CharacterId { get; set; }
    public string ItemName { get; set; } = null!;
    public string ItemDescription { get; set; } = null!;
}
