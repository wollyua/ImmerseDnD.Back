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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FNVUUD6\\SQLEXPRESS01;Initial Catalog=immerse_dnd;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attacks__3214EC279960B4E4");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Character).WithMany(p => p.Attacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attacks__Charact__656C112C");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC2760423CA5");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.Characters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character__UserI__5DCAEF64");
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC278CE8F31F");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Character).WithMany(p => p.InventoryItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Chara__619B8048");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27036D7B2B");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
