using System;
using System.Linq;
using Core.Domain.Entities.Common;
using Core.Domain.Entities.Security;
using Core.Domain.Entities.Specific;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Api.Context
{
    public class DataContext : IdentityDbContext<User, Role, int>, IData
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobLaborer> JobLaborer { get; set; }
        public DbSet<JobProvider> JobProvider { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public IConfiguration Settings { get; }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
        {
            Settings = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
            => dbContextOptionsBuilder
                .UseSqlServer(Settings.GetConnectionString("DefaultConnection"));

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);

            //Customize data tables
            builder.Entity<User>(b =>
            {
                b.HasKey(key => key.Id);

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                b.ToTable(name: "User");
            });

            builder.Entity<Role>(entity =>
            {
                //entity.HasKey(key => key.Id);

                // Each Role can have many entries in the UserRole join table
                entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                entity.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();

                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.HasKey(r => new { r.UserId, r.RoleId });
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
                entity.ToTable("UserToken");
            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.HasKey(rc => rc.Id);
                entity.ToTable("RoleClaim");
            });
        }
    }
}
