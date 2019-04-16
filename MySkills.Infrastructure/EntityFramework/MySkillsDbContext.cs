using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySkills.Core.Entities;
//using MySkills.Persistence.Configurations;

namespace MySkills.Infrastructure.EntityFramework
{
    public class MySkillsDbContext : DbContext
    {
        public MySkillsDbContext(DbContextOptions<MySkillsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Certifications> Certifications { get; set; }
        public virtual DbSet<ExcelExports> ExcelExports { get; set; }
        public virtual DbSet<HistoUserSkills> HistoUserSkills { get; set; }
        public virtual DbSet<ImportFiles> ImportFiles { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Parametres> Parametres { get; set; }
        public virtual DbSet<ProductionUnits> ProductionUnits { get; set; }
        public virtual DbSet<PropCertifications> PropCertifications { get; set; }
        public virtual DbSet<PropSkills> PropSkills { get; set; }
        public virtual DbSet<Ptlcertifications> Ptlcertifications { get; set; }
        public virtual DbSet<Ptlskills> Ptlskills { get; set; }
        public virtual DbSet<Ranks> Ranks { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<Tumranks> Tumranks { get; set; }
        public virtual DbSet<UserCertifications> UserCertifications { get; set; }
        public virtual DbSet<UserSkillL3> UserSkillL3 { get; set; }
        public virtual DbSet<UserSkills> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySkillsDbContext).Assembly);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.RankId)
                    .HasName("IX_RankId");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Adident)
                    .IsRequired()
                    .HasColumnName("ADIdent");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.Ranks_RankId");
            });

            modelBuilder.Entity<Certifications>(entity =>
            {
                entity.HasKey(e => e.CertificationId)
                    .HasName("PK_dbo.Certifications");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_ParentId");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Certifications_dbo.Certifications_ParentId");
            });

            modelBuilder.Entity<ExcelExports>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExcelExports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.ExcelExports_dbo.AspNetUsers_User_Id");
            });

            modelBuilder.Entity<HistoUserSkills>(entity =>
            {
                entity.HasKey(e => e.HistoUserSkillId)
                    .HasName("PK_dbo.HistoUserSkills");

                entity.Property(e => e.Date)
                    .HasColumnName("_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ImportFiles>(entity =>
            {
                entity.HasKey(e => e.ImportFileId)
                    .HasName("PK_dbo.ImportFiles");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateImport).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.ImportFiles)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.ImportFiles_dbo.AspNetUsers_ApplicationUserId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PK_dbo.Notes");
            });

            modelBuilder.Entity<Parametres>(entity =>
            {
                entity.HasKey(e => e.ParametreId)
                    .HasName("PK_dbo.Parametres");
            });

            modelBuilder.Entity<PropCertifications>(entity =>
            {
                entity.HasKey(e => e.PropCertificationId)
                    .HasName("PK_dbo.PropCertifications");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.ParentPropCertificationId)
                    .HasName("IX_Parent_PropCertificationId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateProposition).HasColumnType("datetime");

                entity.Property(e => e.ParentPropCertificationId).HasColumnName("Parent_PropCertificationId");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.PropCertifications)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.PropCertifications_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.ParentPropCertification)
                    .WithMany(p => p.InverseParentPropCertification)
                    .HasForeignKey(d => d.ParentPropCertificationId)
                    .HasConstraintName("FK_dbo.PropCertifications_dbo.PropCertifications_Parent_PropCertificationId");
            });

            modelBuilder.Entity<PropSkills>(entity =>
            {
                entity.HasKey(e => e.PropSkillId)
                    .HasName("PK_dbo.PropSkills");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.ParentPropSkillId)
                    .HasName("IX_Parent_PropSkillId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateProposition).HasColumnType("datetime");

                entity.Property(e => e.ParentPropSkillId).HasColumnName("Parent_PropSkillId");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.PropSkills)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.PropSkills_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.ParentPropSkill)
                    .WithMany(p => p.InverseParentPropSkill)
                    .HasForeignKey(d => d.ParentPropSkillId)
                    .HasConstraintName("FK_dbo.PropSkills_dbo.PropSkills_Parent_PropSkillId");
            });

            modelBuilder.Entity<Ptlcertifications>(entity =>
            {
                entity.HasKey(e => e.PtlcertifId)
                    .HasName("PK_dbo.PTLCertifications");

                entity.ToTable("PTLCertifications");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.CertificationId)
                    .HasName("IX_CertificationId");

                entity.Property(e => e.PtlcertifId).HasColumnName("PTLCertifId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Ptlcertifications)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.PTLCertifications_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.Ptlcertifications)
                    .HasForeignKey(d => d.CertificationId)
                    .HasConstraintName("FK_dbo.PTLCertifications_dbo.Certifications_CertificationId");
            });

            modelBuilder.Entity<Ptlskills>(entity =>
            {
                entity.ToTable("PTLSkills");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.SkillId)
                    .HasName("IX_SkillId");

                entity.Property(e => e.PtlskillsId).HasColumnName("PTLSkillsId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Ptlskills)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.PTLSkills_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Ptlskills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_dbo.PTLSkills_dbo.Skills_SkillId");
            });

            modelBuilder.Entity<Ranks>(entity =>
            {
                entity.HasKey(e => e.RankId)
                    .HasName("PK_dbo.Ranks");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => e.SkillId)
                    .HasName("PK_dbo.Skills");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_ParentId");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Skills_dbo.Skills_ParentId");
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK_dbo.Staffs");

                entity.HasIndex(e => e.ProductionUnitId)
                    .HasName("IX_ProductionUnit_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_user_Id");

                entity.Property(e => e.AvailabaleDate).HasColumnType("datetime");

                entity.Property(e => e.ProductionUnitId).HasColumnName("ProductionUnit_Id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.ProductionUnit)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.ProductionUnitId)
                    .HasConstraintName("FK_dbo.Staffs_dbo.ProductionUnits_ProductionUnit_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Staffs_dbo.AspNetUsers_user_Id");
            });

            modelBuilder.Entity<Tumranks>(entity =>
            {
                entity.HasKey(e => new { e.RankId, e.ApplicationUserId })
                    .HasName("PK_dbo.TUMRanks");

                entity.ToTable("TUMRanks");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.RankId)
                    .HasName("IX_RankId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Tumranks)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.TUMRanks_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Tumranks)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_dbo.TUMRanks_dbo.Ranks_RankId");
            });

            modelBuilder.Entity<UserCertifications>(entity =>
            {
                entity.HasKey(e => new { e.CertificationId, e.ApplicationUserId })
                    .HasName("PK_dbo.UserCertifications");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.CertificationId)
                    .HasName("IX_CertificationId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DateValidation).HasColumnType("datetime");

                entity.Property(e => e.Etat).HasColumnName("etat");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserCertifications)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.UserCertifications_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.UserCertifications)
                    .HasForeignKey(d => d.CertificationId)
                    .HasConstraintName("FK_dbo.UserCertifications_dbo.Certifications_CertificationId");
            });

            modelBuilder.Entity<UserSkillL3>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.ApplicationUserId })
                    .HasName("PK_dbo.UserSkillL3");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.SkillId)
                    .HasName("IX_SkillId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserSkillL3)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.UserSkillL3_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkillL3)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_dbo.UserSkillL3_dbo.Skills_SkillId");
            });

            modelBuilder.Entity<UserSkills>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.ApplicationUserId })
                    .HasName("PK_dbo.UserSkills");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUserId");

                entity.HasIndex(e => e.NoteId)
                    .HasName("IX_NoteId");

                entity.HasIndex(e => e.SkillId)
                    .HasName("IX_SkillId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(128);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateValidation).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Etat).HasColumnName("etat");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.UserSkills_dbo.AspNetUsers_ApplicationUserId");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK_dbo.UserSkills_dbo.Notes_NoteId");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_dbo.UserSkills_dbo.Skills_SkillId");
            });
        }
    }
}
