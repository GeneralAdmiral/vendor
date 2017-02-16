using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using vendor.domain.data.concretes;

namespace vendor.domain.Migrations
{
    [DbContext(typeof(VendorDbContext))]
    [Migration("20161228180847_Rename")]
    partial class Rename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserLogin<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<long>");
                });

            modelBuilder.Entity("vendor.domain.entities.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Update");

                    b.Property<long>("UserUpDateId");

                    b.Property<long>("UserUpdateId");

                    b.HasKey("Id");

                    b.HasIndex("UserUpDateId")
                        .IsUnique();

                    b.HasIndex("UserUpdateId")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("vendor.domain.entities.manytomany.ProductLanguage", b =>
                {
                    b.Property<long>("ParentId");

                    b.Property<long>("LanguageId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Update");

                    b.Property<long>("UserUpdateId");

                    b.HasKey("ParentId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserUpdateId");

                    b.ToTable("ProductLanguages");
                });

            modelBuilder.Entity("vendor.domain.entities.manytomany.UserProduct", b =>
                {
                    b.Property<long>("ParentId");

                    b.Property<long>("ProductId");

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime?>("BuyingDate");

                    b.HasKey("ParentId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserProducts");
                });

            modelBuilder.Entity("vendor.domain.entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image");

                    b.Property<DateTime>("Update");

                    b.Property<long>("UserUpdateId");

                    b.HasKey("Id");

                    b.HasIndex("UserUpdateId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("vendor.domain.entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<DateTime>("Update");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("vendor.domain.entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsBlocked");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("Update");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("vendor.domain.entities.RoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>");


                    b.ToTable("RoleClaims");

                    b.HasDiscriminator().HasValue("RoleClaim");
                });

            modelBuilder.Entity("vendor.domain.entities.UserClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>");


                    b.ToTable("UserClaims");

                    b.HasDiscriminator().HasValue("UserClaim");
                });

            modelBuilder.Entity("vendor.domain.entities.UserLogin", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>");


                    b.ToTable("UserLogins");

                    b.HasDiscriminator().HasValue("UserLogin");
                });

            modelBuilder.Entity("vendor.domain.entities.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>");


                    b.ToTable("UserRoles");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("vendor.domain.entities.UserToken", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<long>");


                    b.ToTable("UserTokens");

                    b.HasDiscriminator().HasValue("UserToken");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("vendor.domain.entities.Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("vendor.domain.entities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("vendor.domain.entities.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>", b =>
                {
                    b.HasOne("vendor.domain.entities.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vendor.domain.entities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vendor.domain.entities.Language", b =>
                {
                    b.HasOne("vendor.domain.entities.User", "UserUpdate")
                        .WithOne("Language")
                        .HasForeignKey("vendor.domain.entities.Language", "UserUpDateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vendor.domain.entities.User", "UserLanguage")
                        .WithOne("UserLanguage")
                        .HasForeignKey("vendor.domain.entities.Language", "UserUpdateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vendor.domain.entities.manytomany.ProductLanguage", b =>
                {
                    b.HasOne("vendor.domain.entities.Language", "Language")
                        .WithMany("ProductLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vendor.domain.entities.Product", "Parent")
                        .WithMany("ProductLanguages")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vendor.domain.entities.User", "UserUpdate")
                        .WithMany("ProductLanguages")
                        .HasForeignKey("UserUpdateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vendor.domain.entities.manytomany.UserProduct", b =>
                {
                    b.HasOne("vendor.domain.entities.User", "Parent")
                        .WithMany("UserProducts")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vendor.domain.entities.Product", "Product")
                        .WithMany("UserProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vendor.domain.entities.Product", b =>
                {
                    b.HasOne("vendor.domain.entities.User", "UserUpdate")
                        .WithOne("Product")
                        .HasForeignKey("vendor.domain.entities.Product", "UserUpdateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
