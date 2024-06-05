using System;
using System.Collections.Generic;
using ImmerseDnD.Back.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Repository;

public partial class immerse_dndDbContext : DbContext
{
	public immerse_dndDbContext()
	{
	}

	public immerse_dndDbContext(DbContextOptions<immerse_dndDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Attack> Attacks { get; set; }

	public virtual DbSet<Character> Characters { get; set; }

	public virtual DbSet<InventoryItem> InventoryItems { get; set; }

	public virtual DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Attack>(entity =>
		{
			entity.HasKey(e => e.AttackId).HasName("PK__Attacks__3214EC279960B4E4");

			entity.Property(e => e.AttackId).HasDefaultValueSql("(newid())");

			entity.HasOne(d => d.Character).WithMany(p => p.Attacks)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Attacks__Charact__656C112C");
		});

		modelBuilder.Entity<Character>(entity =>
		{
			entity.HasKey(e => e.CharacterId).HasName("PK__Characte__3214EC2760423CA5");

			entity.Property(e => e.CharacterId).HasDefaultValueSql("(newid())");

			entity.HasOne(d => d.User).WithMany(p => p.Characters)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Character__UserI__5DCAEF64");
		});

		modelBuilder.Entity<InventoryItem>(entity =>
		{
			entity.HasKey(e => e.ItemId).HasName("PK__Inventor__3214EC278CE8F31F");

			entity.Property(e => e.ItemId).HasDefaultValueSql("(newid())");

			entity.HasOne(d => d.Character).WithMany(p => p.InventoryItems)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Inventory__Chara__619B8048");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.UserId).HasName("PK__Users__3214EC27036D7B2B");

			entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
		});

		modelBuilder.Entity<Character>()
			.HasMany(c => c.Attacks)
			.WithOne(a => a.Character)
			.HasForeignKey(a => a.CharacterId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Character>()
			.HasMany(c => c.InventoryItems)
			.WithOne(i => i.Character)
			.HasForeignKey(i => i.CharacterId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<User>()
			.HasMany(u => u.Characters)
			.WithOne(c => c.User)
			.HasForeignKey(c => c.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
