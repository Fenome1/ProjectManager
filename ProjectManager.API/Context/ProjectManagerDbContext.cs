using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Models;

namespace ProjectManager.API.Context;

public partial class ProjectManagerDbContext : DbContext
{
    public ProjectManagerDbContext()
    {
    }

    public ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Column> Columns { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Name=ProjectManager");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.IdAgency);

            entity.ToTable("Agency");

            entity.HasIndex(e => e.Name, "UQ_Agency").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.IdBoard);

            entity.ToTable("Board");

            entity.HasIndex(e => new { e.IdBoard, e.Name }, "UQ_Board").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.Boards)
                .HasForeignKey(d => d.IdProject)
                .HasConstraintName("FK_Project_Board");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.IdColor);

            entity.ToTable("Color");

            entity.Property(e => e.HexCode).HasMaxLength(9);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Column>(entity =>
        {
            entity.HasKey(e => e.IdColumn);

            entity.ToTable("Column");

            entity.HasIndex(e => e.Name, "UQ_Column");

            entity.Property(e => e.IdColor).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdBoardNavigation).WithMany(p => p.Columns)
                .HasForeignKey(d => d.IdBoard)
                .HasConstraintName("FK_Board_Column");

            entity.HasOne(d => d.IdColorNavigation).WithMany(p => p.Columns)
                .HasForeignKey(d => d.IdColor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Color_Column");
        });

        modelBuilder.Entity<Objective>(entity =>
        {
            entity.HasKey(e => e.IdObjective);

            entity.ToTable("Objective");

            entity.HasIndex(e => e.Name, "UQ_Objective");

            entity.Property(e => e.Deadline).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdColumnNavigation).WithMany(p => p.Objectives)
                .HasForeignKey(d => d.IdColumn)
                .HasConstraintName("FK_Objective_Column");

            entity.HasOne(d => d.IdPriorityNavigation).WithMany(p => p.Objectives)
                .HasForeignKey(d => d.IdPriority)
                .HasConstraintName("FK_Objective_Priority");

            entity.HasMany(d => d.IdUsers).WithMany(p => p.IdObjectives)
                .UsingEntity<Dictionary<string, object>>(
                    "ObjectiveUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_ObjectiveUser_User"),
                    l => l.HasOne<Objective>().WithMany()
                        .HasForeignKey("IdObjective")
                        .HasConstraintName("FK_ObjectiveUser_Objective"),
                    j =>
                    {
                        j.HasKey("IdObjective", "IdUser");
                        j.ToTable("ObjectiveUser");
                        j.HasIndex(new[] { "IdObjective", "IdUser" }, "UQ_Objective_User").IsUnique();
                    });
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.IdPriority);

            entity.ToTable("Priority");

            entity.Property(e => e.HexCode).HasMaxLength(9);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject);

            entity.ToTable("Project");

            entity.HasIndex(e => e.Name, "UQ_Project");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdAgencyNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdAgency)
                .HasConstraintName("FK_Project_Agency");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ_Role").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IdRole).HasDefaultValueSql("((1))");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}