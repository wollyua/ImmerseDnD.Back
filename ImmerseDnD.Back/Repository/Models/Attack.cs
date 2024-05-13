using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Repository.Models;

public partial class Attack
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [Column("CharacterID")]
    public Guid CharacterId { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string AttackName { get; set; } = null!;

    public short? AttackRange { get; set; }

    public byte DiceNumber { get; set; }

    public byte DiceType { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string DamageType { get; set; } = null!;

    [ForeignKey("CharacterId")]
    [InverseProperty("Attacks")]
    public virtual Character Character { get; set; } = null!;
}
