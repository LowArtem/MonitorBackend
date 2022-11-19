using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MonitorBackend.Data.Entity;
using Object = MonitorBackend.Data.Entity.Object;

namespace MonitorBackend.Data;

public partial class MonitorDbContext : DbContext
{
    public MonitorDbContext()
    {
    }

    public MonitorDbContext(DbContextOptions<MonitorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alertlevel> Alertlevels { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Load> Loads { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Malwarereport> Malwarereports { get; set; }

    public virtual DbSet<Malwaretype> Malwaretypes { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<Typesoflog> Typesoflogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MonitorDb;Username=postgres;Password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alertlevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alertlevels_pkey");

            entity.ToTable("alertlevels");

            entity.HasIndex(e => e.Name, "alertlevels_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("devices_pkey");

            entity.ToTable("devices");

            entity.HasIndex(e => e.Name, "devices_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Load>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("loads_pkey");

            entity.ToTable("loads");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.IdDevice).HasColumnName("id_device");
            entity.Property(e => e.IdObject).HasColumnName("id_object");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.IdDeviceNavigation).WithMany(p => p.Loads)
                .HasForeignKey(d => d.IdDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loads_id_device_fkey");

            entity.HasOne(d => d.IdObjectNavigation).WithMany(p => p.Loads)
                .HasForeignKey(d => d.IdObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loads_id_object_fkey");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("logs_pkey");

            entity.ToTable("logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.IdAlertlevel).HasColumnName("id_alertlevel");
            entity.Property(e => e.IdDevice).HasColumnName("id_device");
            entity.Property(e => e.IdTypeoflog).HasColumnName("id_typeoflog");
            entity.Property(e => e.Instanceid).HasColumnName("instanceid");
            entity.Property(e => e.Source)
                .HasMaxLength(100)
                .HasColumnName("source");
            entity.Property(e => e.Timegenerated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timegenerated");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.IdAlertlevelNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdAlertlevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("logs_id_alertlevel_fkey");

            entity.HasOne(d => d.IdDeviceNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("logs_id_device_fkey");

            entity.HasOne(d => d.IdTypeoflogNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdTypeoflog)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("logs_id_typeoflog_fkey");
        });

        modelBuilder.Entity<Malwarereport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("malwarereports_pkey");

            entity.ToTable("malwarereports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Filepath)
                .HasMaxLength(100)
                .HasColumnName("filepath");
            entity.Property(e => e.IdDevice).HasColumnName("id_device");
            entity.Property(e => e.IdMalwaretype).HasColumnName("id_malwaretype");

            entity.HasOne(d => d.IdDeviceNavigation).WithMany(p => p.Malwarereports)
                .HasForeignKey(d => d.IdDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("malwarereports_id_device_fkey");

            entity.HasOne(d => d.IdMalwaretypeNavigation).WithMany(p => p.Malwarereports)
                .HasForeignKey(d => d.IdMalwaretype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("malwarereports_id_malwaretype_fkey");
        });

        modelBuilder.Entity<Malwaretype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("malwaretypes_pkey");

            entity.ToTable("malwaretypes");

            entity.HasIndex(e => e.Name, "malwaretypes_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("objects_pkey");

            entity.ToTable("objects");

            entity.HasIndex(e => e.Name, "objects_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Typesoflog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typesoflogs_pkey");

            entity.ToTable("typesoflogs");

            entity.HasIndex(e => e.Name, "typesoflogs_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
