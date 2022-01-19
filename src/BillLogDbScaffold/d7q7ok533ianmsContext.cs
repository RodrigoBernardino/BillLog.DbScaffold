using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BillLogDbScaffold
{
    public partial class d7q7ok533ianmsContext : DbContext
    {
        public d7q7ok533ianmsContext()
        {
        }

        public d7q7ok533ianmsContext(DbContextOptions<d7q7ok533ianmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillTag> BillTags { get; set; }
        public virtual DbSet<Revenue> Revenues { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scope> Scopes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }
        public virtual DbSet<UsersScope> UsersScopes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=tdifsahortdjuq;Password=ff0e0ae7dd75b2afe782fc9f23e66e6f37c2327d924fc6ea409f14f032c1b350;Host=ec2-34-206-245-175.compute-1.amazonaws.com;Port=5432;Database=d7q7ok533ianms");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bills", "billlog.sql");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.HasOne(d => d.BillTag)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.BillTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bills_billtags");

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ScopeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bills_scopes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bills_users");
            });

            modelBuilder.Entity<BillTag>(entity =>
            {
                entity.ToTable("BillTags", "billlog.sql");

                entity.HasIndex(e => e.Name, "billtags_unique_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Revenue>(entity =>
            {
                entity.ToTable("Revenues", "billlog.sql");

                entity.HasIndex(e => e.UserId, "revenues_unique_userid")
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Revenue)
                    .HasForeignKey<Revenue>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_revenues_users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "billlog.sql");

                entity.HasIndex(e => e.Name, "unique_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Scope>(entity =>
            {
                entity.ToTable("Scopes", "billlog.sql");

                entity.HasIndex(e => e.Name, "scopes_constraint_unique_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.Scopes)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_scope_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "billlog.sql");

                entity.HasIndex(e => e.Email, "unique_email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users_Roles", "billlog.sql");

                entity.HasIndex(e => new { e.UserId, e.RoleId }, "unique_index")
                    .IsUnique();

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_roles_roles");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_roles_users");
            });

            modelBuilder.Entity<UsersScope>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users_Scopes", "billlog.sql");

                entity.HasIndex(e => new { e.UserId, e.ScopeId }, "unique_users_scopes")
                    .IsUnique();

                entity.HasOne(d => d.Scope)
                    .WithMany()
                    .HasForeignKey(d => d.ScopeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_scopes_scopes");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users_scopes_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
