using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Repository.Models;

public partial class Character
{
    [Key]
    [Column("ID")]
    public Guid CharacterId { get; set; }

    [Column("UserID")]
    public Guid UserId { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string CharacterName { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string CharacterRace { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string CharacterClass { get; set; } = null!;

    public byte CharacterLevel { get; set; }

    public byte Strength { get; set; }

    public byte Dexterity { get; set; }

    public byte Constitution { get; set; }

    public byte Intelligence { get; set; }

    public byte Wisdom { get; set; }

    public byte Charisma { get; set; }

    [Column("bonStr")]
    public bool BonStr { get; set; }

    [Column("bonCon")]
    public bool BonCon { get; set; }

    [Column("bonDex")]
    public bool BonDex { get; set; }

    [Column("bonInt")]
    public bool BonInt { get; set; }

    [Column("bonWis")]
    public bool BonWis { get; set; }

    [Column("bonCha")]
    public bool BonCha { get; set; }

    public bool Inspiration { get; set; }

    public byte ProficiencyBonus { get; set; }

    public byte Armor { get; set; }

    public byte Speed { get; set; }

    [Column("CurrentHP")]
    public short CurrentHp { get; set; }

    [Column("MaxHP")]
    public short MaxHp { get; set; }

    [Column("TempHP")]
    public short TempHp { get; set; }

    public int Copper { get; set; }

    public int Silver { get; set; }

    public int Gold { get; set; }

    public int Platinum { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? Languages { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? PersonalityTraits { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? Ideals { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? Bonds { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? Flaws { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? OtherTraits { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<Attack> Attacks { get; set; } = new List<Attack>();

    [InverseProperty("Character")]
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    [ForeignKey("UserId")]
    [InverseProperty("Characters")]
    public virtual User User { get; set; } = null!;
}

public class CharacterDto
{
    public Guid CharacterId { get; set; }
    public string CharacterName { get; set; } = null!;
    public string CharacterRace { get; set; } = null!;
    public string CharacterClass { get; set; } = null!;
    public byte CharacterLevel { get; set; }
    public byte Strength { get; set; }
    public byte Dexterity { get; set; }
    public byte Constitution { get; set; }
    public byte Intelligence { get; set; }
    public byte Wisdom { get; set; }
    public byte Charisma { get; set; }
    public bool BonStr { get; set; }
    public bool BonCon { get; set; }
    public bool BonDex { get; set; }
    public bool BonInt { get; set; }
    public bool BonWis { get; set; }
    public bool BonCha { get; set; }
    public bool Inspiration { get; set; }
    public byte ProficiencyBonus { get; set; }
    public byte Armor { get; set; }
    public byte Speed { get; set; }
    public short CurrentHp { get; set; }
    public short MaxHp { get; set; }
    public short TempHp { get; set; }
    public int Copper { get; set; }
    public int Silver { get; set; }
    public int Gold { get; set; }
    public int Platinum { get; set; }
    public string? Languages { get; set; }
    public string? PersonalityTraits { get; set; }
    public string? Ideals { get; set; }
    public string? Bonds { get; set; }
    public string? Flaws { get; set; }
    public string? OtherTraits { get; set; }
}

public class CharacterPreviewDto
{
    public Guid CharacterId { get; set; }
    public Guid UserId { get; set; }
    public string CharacterName { get; set; } = null!;
    public string CharacterRace { get; set; } = null!;
    public string CharacterClass { get; set; } = null!;
    public byte CharacterLevel { get; set; }
    public byte Strength { get; set; }
    public byte Dexterity { get; set; }
    public byte Constitution { get; set; }
    public byte Intelligence { get; set; }
    public byte Wisdom { get; set; }
    public byte Charisma { get; set; }
}

public class UpdateHealthDto
{
    public short CurrentHp { get; set; }
    public short TempHp { get; set; }
}