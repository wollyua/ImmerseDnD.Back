using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Repository.Models
{
    public class CharacterPreview
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

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
    }
}
