﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneAxis.Infrastructure.Persistence;

#nullable disable

namespace PhoneAxis.Infrastructure.Migrations
{
    [DbContext(typeof(PhoneAxisDbContext))]
    partial class PhoneAxisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_app_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("role_name_index");

                    b.ToTable("app_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_app_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_app_role_claims_role_id");

                    b.ToTable("app_role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_app_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_app_user_claims_user_id");

                    b.ToTable("app_user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_app_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_app_user_logins_user_id");

                    b.ToTable("app_user_logins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_app_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_app_user_roles_role_id");

                    b.ToTable("app_user_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("longtext")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_app_user_tokens");

                    b.ToTable("app_user_tokens", (string)null);
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_carts");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_carts_user_id");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("char(36)")
                        .HasColumnName("cart_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("unit_price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_cart_items");

                    b.HasIndex("CartId")
                        .HasDatabaseName("ix_cart_items_cart_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_cart_items_product_id");

                    b.ToTable("cart_items");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("category_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.MasterUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("longtext")
                        .HasColumnName("contact_email");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_master_users");

                    b.ToTable("master_users");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("customer_name");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("customer_phone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<string>("OrderCode")
                        .HasColumnType("longtext")
                        .HasColumnName("order_code");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("order_date");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("shipping_address");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("total_amount");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)")
                        .HasColumnName("order_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("unit_price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_order_details");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_details_order_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_order_details_product_id");

                    b.ToTable("order_details");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_featured");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.Property<string>("ProductCode")
                        .HasColumnType("longtext")
                        .HasColumnName("product_code");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext")
                        .HasColumnName("product_name");

                    b.Property<int>("ProductType")
                        .HasColumnType("int")
                        .HasColumnName("product_type");

                    b.Property<string>("Sku")
                        .HasColumnType("longtext")
                        .HasColumnName("sku");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext")
                        .HasColumnName("updated_by");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_product_images");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_product_images_product_id");

                    b.ToTable("product_images");
                });

            modelBuilder.Entity("PhoneAxis.Infrastructure.Persistence.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext")
                        .HasColumnName("refresh_token");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_app_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("email_index");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("user_name_index");

                    b.ToTable("app_users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_role_claims_app_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PhoneAxis.Infrastructure.Persistence.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_claims_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PhoneAxis.Infrastructure.Persistence.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_logins_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_roles_app_roles_role_id");

                    b.HasOne("PhoneAxis.Infrastructure.Persistence.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_roles_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PhoneAxis.Infrastructure.Persistence.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_tokens_users_user_id");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Cart", b =>
                {
                    b.HasOne("PhoneAxis.Domain.Entities.MasterUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_carts_master_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("PhoneAxis.Domain.Entities.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .HasConstraintName("fk_cart_items_carts_cart_id");

                    b.HasOne("PhoneAxis.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cart_items_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("PhoneAxis.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_details_orders_order_id");

                    b.HasOne("PhoneAxis.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_details_products_product_id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Product", b =>
                {
                    b.HasOne("PhoneAxis.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("PhoneAxis.Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_images_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("PhoneAxis.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
