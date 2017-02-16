using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vendor.domain.entities;
using vendor.domain.entities.manytomany;

namespace vendor.domain.data.concretes
{

    public class VendorDbContext : IdentityDbContext<User, Role, long> //, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> 
    {
        public VendorDbContext(DbContextOptions<VendorDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.OnModelCreatingSeed();
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }

        // Many to many
        // public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<ProductLanguage> ProductLanguages { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

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