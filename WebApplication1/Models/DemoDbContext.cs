using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class DemoDbContext : DbContext
{
    public DemoDbContext()
    {
    }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberType> MemberTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.94\\SQLEXPRESS; Database=DemoDb; User Id=sa; Password=0613562557; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_100_CI_AS");

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.MemberName)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.MemberTypeCode).HasMaxLength(10);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.MemberTypeCodeNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.MemberTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Members_MemberType");
        });

        modelBuilder.Entity<MemberType>(entity =>
        {
            entity.HasKey(e => e.MemberTypeCode);

            entity.ToTable("MemberType");

            entity.Property(e => e.MemberTypeCode).HasMaxLength(10);
            entity.Property(e => e.MemberTypeName).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
