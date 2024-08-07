﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Repository.Models;

public partial class User
{
    [Key]
    [Column("ID")]
    public Guid UserId { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string UserEmail { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string UserPassword { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}

public class UserDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string UserEmail { get; set; } = null!;
    public string UserPassword { get; set; } = null!;
}