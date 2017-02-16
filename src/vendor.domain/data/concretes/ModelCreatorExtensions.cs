using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendor.domain.entities;
using vendor.domain.entities.manytomany;

namespace vendor.domain.data.concretes
{
    public static class ModelCreatorExtensions
    {
        public static void OnModelCreatingSeed(this ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity
                    .HasOne(p => p.UserLanguage)
                    .WithOne(p => p.UserLanguage)
                    .HasForeignKey<Language>(p => p.UserUpdateId);
            });

            builder.Entity<Role>(entity => entity.ToTable("Roles"));

            builder.Entity<UserRole>(entity => entity.ToTable("UserRoles"));

            builder.Entity<UserLogin>(entity => entity.ToTable("UserLogins"));

            builder.Entity<UserClaim>(entity => entity.ToTable("UserClaims"));

            builder.Entity<RoleClaim>(entity => entity.ToTable("RoleClaims"));

            builder.Entity<UserToken>(entity => entity.ToTable("UserTokens"));

            builder.Entity<Product>(entity => {
                entity
                    .ToTable("Products");

                entity
                    .HasOne(pl => pl.UserUpdate)
                    .WithOne(pl => pl.Product)
                    .HasForeignKey<Product>(pl => pl.UserUpdateId);
            });

            builder.Entity<Language>(entity => {
                entity
                    .ToTable("Languages");

                entity
                    .HasOne(l => l.UserUpdate)
                    .WithOne(l => l.Language)
                    .HasForeignKey<Language>(l => l.UserUpDateId);
            });

            builder.Entity<ProductLanguage>(entity =>
            {
                entity
                    .ToTable("ProductLanguages");

                entity
                    .HasKey(key => new { key.ParentId, key.LanguageId });

                entity
                    .HasOne(pl => pl.Parent)
                    .WithMany(pl => pl.ProductLanguages)
                    .HasForeignKey(pl => pl.ParentId);

                entity
                    .HasOne(pl => pl.UserUpdate)
                    .WithMany(pl => pl.ProductLanguages)
                    .HasForeignKey(pl => pl.UserUpdateId);

                entity
                    .HasOne(pl => pl.Language)
                    .WithMany(pl => pl.ProductLanguages)
                    .HasForeignKey(pl => pl.LanguageId);

            });

            builder.Entity<UserProduct>(entity => {
                entity
                    .ToTable("UserProducts");

                entity
                    .HasKey(key => new { key.ParentId, key.ProductId });

                entity
                    .HasOne(pl => pl.Parent)
                    .WithMany(pl => pl.UserProducts)
                    .HasForeignKey(pl => pl.ParentId);

                entity
                    .HasOne(pl => pl.Product)
                    .WithMany(pl => pl.UserProducts)
                    .HasForeignKey(pl => pl.ProductId);

            });
        }
    }
}
