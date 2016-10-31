using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vendor.domain.entities;

namespace vendor.domain.data.concretes
{

    public class VendorDbContext : IdentityDbContext<User, Role, long>//, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> 
    {
        public VendorDbContext(DbContextOptions<VendorDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Server=localhost;Database=VendorDb;Trusted_Connection=True;MultipleActiveResultSets=true"); "Host=localhost;Port=5432;Database=vendor;Pooling=true;"
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity => entity.ToTable("Users"));

            builder.Entity<Role>(entity => entity.ToTable("Roles"));

            builder.Entity<UserRole>(entity => entity.ToTable("UserRoles"));

            builder.Entity<UserLogin>(entity => entity.ToTable("UserLogins"));

            builder.Entity<UserClaim>(entity => entity.ToTable("UserClaims"));

            builder.Entity<RoleClaim>(entity => entity.ToTable("RoleClaims"));

            builder.Entity<UserToken>(entity => entity.ToTable("UserTokens"));
        }

        public virtual DbSet<LanguageDict> LanguageDict { get; set; }
    }
}



//using System;
//using System.Linq;
//using DomainModel.Model;
//using Microsoft.EntityFrameworkCore;
 
//namespace DataAccessPostgreSqlProvider
//{
//    // >dotnet ef migration add testMigration in AspNet5MultipleProject
//    public class DomainModelPostgreSqlContext : DbContext
//    {
//        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
//        {
//        }

//        public DbSet<DataEventRecord> DataEventRecords { get; set; }

//        public DbSet<SourceInfo> SourceInfos { get; set; }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.Entity<DataEventRecord>().HasKey(m => m.DataEventRecordId);
//            builder.Entity<SourceInfo>().HasKey(m => m.SourceInfoId);

//            // shadow properties
//            builder.Entity<DataEventRecord>().Property<DateTime>("UpdatedTimestamp");
//            builder.Entity<SourceInfo>().Property<DateTime>("UpdatedTimestamp");

//            base.OnModelCreating(builder);
//        }

//        public override int SaveChanges()
//        {
//            ChangeTracker.DetectChanges();

//            updateUpdatedProperty<SourceInfo>();
//            updateUpdatedProperty<DataEventRecord>();

//            return base.SaveChanges();
//        }

//        private void updateUpdatedProperty<T>() where T : class
//        {
//            var modifiedSourceInfo =
//                ChangeTracker.Entries<T>()
//                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

//            foreach (var entry in modifiedSourceInfo)
//            {
//                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
//            }
//        }
//    }
//}