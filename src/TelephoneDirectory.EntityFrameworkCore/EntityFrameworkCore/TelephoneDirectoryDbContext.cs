using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TelephoneDirectory.Authorization.Roles;
using TelephoneDirectory.Authorization.Users;
using TelephoneDirectory.MultiTenancy;
using TelephoneDirectory.Models;
using Abp.Localization;

namespace TelephoneDirectory.EntityFrameworkCore
{
    public class TelephoneDirectoryDbContext : AbpZeroDbContext<Tenant, Role, User, TelephoneDirectoryDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TelephoneDirectoryDbContext(DbContextOptions<TelephoneDirectoryDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }


        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MembersContact> MembersContact { get; set; }
    }
}
