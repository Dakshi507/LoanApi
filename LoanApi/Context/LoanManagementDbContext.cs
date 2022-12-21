using System;
using System.Collections.Generic;
using LoanApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApi.Context;

public partial class LoanManagementDbContext : DbContext
{
    public LoanManagementDbContext()
    {
    }

    public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Loandetail> Loandetails { get; set; }

    public virtual DbSet<Userdetail> Userdetails { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Loandetail>()
            .HasIndex(u => u.Loannumber)
            .IsUnique();
        builder.Entity<Userdetail>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LTIN233652;Initial Catalog=Loan_ManagementDb;Integrated Security=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loandetail>(entity =>
        {
            entity.HasKey(e => e.Loannumber).HasName("PK__loandeta__8740F04421AEDBDE");

            entity.ToTable("loandetails");

            entity.Property(e => e.LoanTerm).HasMaxLength(15);
            entity.Property(e => e.Loantype).HasMaxLength(15);
            entity.Property(e => e.Propertyaddress).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Loandetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__loandetai__UserI__5FB337D6");
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__userdeta__1788CC4C4075579C");

            entity.ToTable("userdetails");

            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .HasColumnName("firstname");
            entity.Property(e => e.Isadmin)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isadmin");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
}
