using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Elearn.Models
{
    public partial class aspnetElearnContext : DbContext
    {
        public aspnetElearnContext()
        {
        }

        public aspnetElearnContext(DbContextOptions<aspnetElearnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asign> Asign { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Design> Design { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestCategory> TestCategory { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitCategory> UnitCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlServer("Server=localhost;Database=aspnet-Elearn;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asign>(entity =>
            {
                entity.Property(e => e.ApplicantId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.AsignerId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.AsignApplicant)
                    .HasForeignKey(d => d.ApplicantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asign_AspNetUsers_Applicant");

                entity.HasOne(d => d.Asigner)
                    .WithMany(p => p.AsignAsigner)
                    .HasForeignKey(d => d.AsignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asign_AspNetUsers");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Asign)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_Asign_Test");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Rfid)
                    .HasColumnName("RFID")
                    .HasMaxLength(45);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_AspNetUsers_Unit_category");
            });

            modelBuilder.Entity<Design>(entity =>
            {
                entity.Property(e => e.Json)
                    .HasColumnName("JSON")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.CompleteTime).HasColumnType("datetime");

                entity.Property(e => e.Json)
                    .IsRequired()
                    .HasColumnName("JSON")
                    .HasColumnType("text");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Asign)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.AsignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Result_Asign");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscription_Unit");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.Property(e => e.Json)
                    .IsRequired()
                    .HasColumnName("JSON")
                    .HasColumnType("text");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Test_Test_Category");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Test_AspNetUsers");
            });

            modelBuilder.Entity<TestCategory>(entity =>
            {
                entity.ToTable("Test_Category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TestCategory)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Test_Category_Unit");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Design)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.DesignId)
                    .HasConstraintName("FK_Unit_Design");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Unit_AspNetUsers");
            });

            modelBuilder.Entity<UnitCategory>(entity =>
            {
                entity.ToTable("Unit_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
