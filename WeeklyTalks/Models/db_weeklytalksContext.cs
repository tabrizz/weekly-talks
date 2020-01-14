using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeeklyTalks.Models
{
    public partial class db_weeklytalksContext : DbContext
    {
        public db_weeklytalksContext()
        {
        }

        public db_weeklytalksContext(DbContextOptions<db_weeklytalksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessUnits> BusinessUnits { get; set; }
        public virtual DbSet<EmployeeMeeting> EmployeeMeeting { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<ModelHasPermissions> ModelHasPermissions { get; set; }
        public virtual DbSet<ModelHasRoles> ModelHasRoles { get; set; }
        public virtual DbSet<OauthAccessTokens> OauthAccessTokens { get; set; }
        public virtual DbSet<OauthAuthCodes> OauthAuthCodes { get; set; }
        public virtual DbSet<OauthClients> OauthClients { get; set; }
        public virtual DbSet<OauthPersonalAccessClients> OauthPersonalAccessClients { get; set; }
        public virtual DbSet<OauthRefreshTokens> OauthRefreshTokens { get; set; }
        public virtual DbSet<Observations> Observations { get; set; }
        public virtual DbSet<OfficeUser> OfficeUser { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<RoleHasPermissions> RoleHasPermissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Suggestions> Suggestions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.password_resets'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=db_weeklytalks; Integrated Security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BusinessUnits>(entity =>
            {
                entity.ToTable("business_units");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeMeeting>(entity =>
            {
                entity.ToTable("employee_meeting");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attended).HasColumnName("attended");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.MissingReason)
                    .HasColumnName("missing_reason")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(191);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(191);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasMaxLength(191);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(191);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Meetings>(entity =>
            {
                entity.ToTable("meetings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1550);

                entity.Property(e => e.DocumentPic)
                    .IsRequired()
                    .HasColumnName("document_pic")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("(N'default.png')");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.SelfiePic)
                    .IsRequired()
                    .HasColumnName("selfie_pic")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("(N'default.png')");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StatusDescription)
                    .HasColumnName("status_description")
                    .HasMaxLength(25);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<ModelHasPermissions>(entity =>
            {
                entity.HasKey(e => new { e.PermissionId, e.ModelId, e.ModelType })
                    .HasName("PK_model_has_permissions_permission_id");

                entity.ToTable("model_has_permissions");

                entity.HasIndex(e => new { e.ModelId, e.ModelType })
                    .HasName("model_has_permissions_model_id_model_type_index");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ModelType)
                    .HasColumnName("model_type")
                    .HasMaxLength(191);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ModelHasPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("model_has_permissions$model_has_permissions_permission_id_foreign");
            });

            modelBuilder.Entity<ModelHasRoles>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.ModelId, e.ModelType })
                    .HasName("PK_model_has_roles_role_id");

                entity.ToTable("model_has_roles");

                entity.HasIndex(e => new { e.ModelId, e.ModelType })
                    .HasName("model_has_roles_model_id_model_type_index");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ModelType)
                    .HasColumnName("model_type")
                    .HasMaxLength(191);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ModelHasRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("model_has_roles$model_has_roles_role_id_foreign");
            });

            modelBuilder.Entity<OauthAccessTokens>(entity =>
            {
                entity.ToTable("oauth_access_tokens");

                entity.HasIndex(e => e.UserId)
                    .HasName("oauth_access_tokens_user_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpiresAt)
                    .HasColumnName("expires_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.Revoked).HasColumnName("revoked");

                entity.Property(e => e.Scopes).HasColumnName("scopes");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<OauthAuthCodes>(entity =>
            {
                entity.ToTable("oauth_auth_codes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ExpiresAt)
                    .HasColumnName("expires_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Revoked).HasColumnName("revoked");

                entity.Property(e => e.Scopes).HasColumnName("scopes");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<OauthClients>(entity =>
            {
                entity.ToTable("oauth_clients");

                entity.HasIndex(e => e.UserId)
                    .HasName("oauth_clients_user_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.PasswordClient).HasColumnName("password_client");

                entity.Property(e => e.PersonalAccessClient).HasColumnName("personal_access_client");

                entity.Property(e => e.Redirect)
                    .IsRequired()
                    .HasColumnName("redirect");

                entity.Property(e => e.Revoked).HasColumnName("revoked");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<OauthPersonalAccessClients>(entity =>
            {
                entity.ToTable("oauth_personal_access_clients");

                entity.HasIndex(e => e.ClientId)
                    .HasName("oauth_personal_access_clients_client_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OauthRefreshTokens>(entity =>
            {
                entity.ToTable("oauth_refresh_tokens");

                entity.HasIndex(e => e.AccessTokenId)
                    .HasName("oauth_refresh_tokens_access_token_id_index");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessTokenId)
                    .IsRequired()
                    .HasColumnName("access_token_id")
                    .HasMaxLength(100);

                entity.Property(e => e.ExpiresAt)
                    .HasColumnName("expires_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Revoked).HasColumnName("revoked");
            });

            modelBuilder.Entity<Observations>(entity =>
            {
                entity.ToTable("observations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OfficeUser>(entity =>
            {
                entity.ToTable("office_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Offices>(entity =>
            {
                entity.ToTable("offices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("permissions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuardName)
                    .IsRequired()
                    .HasColumnName("guard_name")
                    .HasMaxLength(191);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleHasPermissions>(entity =>
            {
                entity.HasKey(e => new { e.PermissionId, e.RoleId })
                    .HasName("PK_role_has_permissions_permission_id");

                entity.ToTable("role_has_permissions");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_has_permissions_role_id_foreign");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RoleHasPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("role_has_permissions$role_has_permissions_permission_id_foreign");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleHasPermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_has_permissions$role_has_permissions_role_id_foreign");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuardName)
                    .IsRequired()
                    .HasColumnName("guard_name")
                    .HasMaxLength(191);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Suggestions>(entity =>
            {
                entity.ToTable("suggestions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users$users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnName("email_verified_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(191);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(15);

                entity.Property(e => e.Token).HasMaxLength(191);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });
        }
    }
}
