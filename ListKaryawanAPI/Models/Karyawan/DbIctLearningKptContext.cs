using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ListKaryawanAPI.Models.Karyawan;

public partial class DbIctLearningKptContext : DbContext
{
    public DbIctLearningKptContext()
    {
    }

    public DbIctLearningKptContext(DbContextOptions<DbIctLearningKptContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblTBiodatum> TblTBiodata { get; set; }

    public virtual DbSet<TblTKaryawan> TblTKaryawans { get; set; }

    public virtual DbSet<VwListKaryawan> VwListKaryawans { get; set; }

    public virtual DbSet<VwMBiodatum> VwMBiodata { get; set; }

    public virtual DbSet<VwMReRegistration2> VwMReRegistration2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.14.101.101\\shpol;Database=DB_ICT_LEARNING_KPT;User Id=sqlservices;Password=sqlservices1;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblTBiodatum>(entity =>
        {
            entity.HasKey(e => e.Nrp);

            entity.ToTable("TBL_T_BIODATA");

            entity.Property(e => e.Nrp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRP");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nama)
                .IsUnicode(false)
                .HasColumnName("NAMA");
            entity.Property(e => e.Telepon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TELEPON");
        });

        modelBuilder.Entity<TblTKaryawan>(entity =>
        {
            entity.HasKey(e => e.Nrp);

            entity.ToTable("TBL_T_KARYAWAN");

            entity.Property(e => e.Nrp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRP");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAMA");
            entity.Property(e => e.NoTlp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NO_TLP");
        });

        modelBuilder.Entity<VwListKaryawan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_List_Karyawan");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAMA");
            entity.Property(e => e.NoTlp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NO_TLP");
            entity.Property(e => e.Nrp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRP");
        });

        modelBuilder.Entity<VwMBiodatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_M_Biodata");

            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nama)
                .IsUnicode(false)
                .HasColumnName("NAMA");
            entity.Property(e => e.Nrp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRP");
            entity.Property(e => e.Telepon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TELEPON");
        });

        modelBuilder.Entity<VwMReRegistration2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_M_reRegistration2");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAMA");
            entity.Property(e => e.NoTlp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NO_TLP");
            entity.Property(e => e.Nrp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NRP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
