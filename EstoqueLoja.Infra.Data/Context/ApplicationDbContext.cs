using System;
using System.Collections.Generic;
using EstoqueLoja.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueLoja.Domain.Entities;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() {
    }

    protected ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) 
    { 
    }

    public virtual DbSet<ItensEstoque> ItensEstoques { get; set; }

    public virtual DbSet<Loja> Lojas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EstoqueLoja;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensEstoque>(entity =>
        {
            entity.HasKey(e => e.IdLoj);

            entity.ToTable("ItensEstoque");

            entity.Property(e => e.IdLoj).ValueGeneratedNever();

            entity.HasOne(d => d.IdLojNavigation).WithOne(p => p.ItensEstoque)
                .HasForeignKey<ItensEstoque>(d => d.IdLoj)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItensEstoque_Loja");

            entity.HasOne(d => d.IdProNavigation).WithMany(p => p.ItensEstoques)
                .HasForeignKey(d => d.IdPro)
                .HasConstraintName("FK_ItensEstoque_Produto");
        });

        modelBuilder.Entity<Loja>(entity =>
        {
            entity.HasKey(e => e.IdLoj).HasName("PK__Loja__0C54DBFB27D3C060");

            entity.ToTable("Loja");

            entity.Property(e => e.IdLoj).ValueGeneratedNever();
            entity.Property(e => e.EnderecoLoj)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeLoj)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("PK__Produto__2ACD4C7ECC93EC17");

            entity.ToTable("Produto");

            entity.Property(e => e.IdPro).ValueGeneratedNever();
            entity.Property(e => e.NomePro)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
