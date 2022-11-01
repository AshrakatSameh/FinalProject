﻿// <auto-generated />
using System;
using FinalProjectModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProjectModels.Migrations
{
    [DbContext(typeof(FinalProjectEntity))]
    partial class FinalProjectEntityModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinalProjectDB.Models.البضاعه", b =>
                {
                    b.Property<int>("رقم_الصنف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الصنف"), 1L, 1);

                    b.Property<int>("اجمالي_الكميه")
                        .HasColumnType("int");

                    b.Property<string>("اسم_الصنف")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("الوصف")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("بيعرقم_الصنف")
                        .HasColumnType("int");

                    b.Property<double>("سعر_البيع")
                        .HasColumnType("float");

                    b.Property<double>("سعر_الشراء")
                        .HasColumnType("float");

                    b.Property<int>("شراءرقم_الصنف")
                        .HasColumnType("int");

                    b.Property<int>("مرتجع_بيعرقم_الصنف")
                        .HasColumnType("int");

                    b.Property<int>("مرتجع_شراءرقم_الصنف")
                        .HasColumnType("int");

                    b.HasKey("رقم_الصنف");

                    b.HasIndex("بيعرقم_الصنف");

                    b.HasIndex("شراءرقم_الصنف");

                    b.HasIndex("مرتجع_بيعرقم_الصنف");

                    b.HasIndex("مرتجع_شراءرقم_الصنف");

                    b.ToTable("البضاعه");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الحسابات", b =>
                {
                    b.Property<int>("رقم_الحساب")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الحساب"), 1L, 1);

                    b.Property<string>("اسم_الحساب")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("التصنيف")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("التليفون")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("العنوان")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("دائن")
                        .HasColumnType("float");

                    b.Property<string>("طبيعه_الحساب")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("كود_الحساب")
                        .HasColumnType("int");

                    b.Property<double>("مدين")
                        .HasColumnType("float");

                    b.HasKey("رقم_الحساب");

                    b.ToTable("الحسابات");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الخزنه", b =>
                {
                    b.Property<int>("رقم_المسلسل")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_المسلسل"), 1L, 1);

                    b.Property<DateTime>("التاريخ")
                        .HasColumnType("datetime2");

                    b.Property<string>("الحركه")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الحساب")
                        .HasColumnType("float");

                    b.Property<double>("رصيد")
                        .HasColumnType("float");

                    b.Property<double>("منصرف")
                        .HasColumnType("float");

                    b.Property<double>("وارد")
                        .HasColumnType("float");

                    b.HasKey("رقم_المسلسل");

                    b.ToTable("الخزنه");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الفواتير", b =>
                {
                    b.Property<int>("رقم_الفاتوره")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الفاتوره"), 1L, 1);

                    b.Property<DateTime>("التاريخ")
                        .HasColumnType("datetime2");

                    b.Property<string>("الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الخصم")
                        .HasColumnType("float");

                    b.Property<int>("الكميه")
                        .HasColumnType("int");

                    b.Property<double>("النهائي")
                        .HasColumnType("float");

                    b.Property<double>("درج_النقديه")
                        .HasColumnType("float");

                    b.Property<string>("طريقه_الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الفاتوره");

                    b.ToTable("الفواتير");
                });

            modelBuilder.Entity("FinalProjectDB.Models.بيع", b =>
                {
                    b.Property<int>("رقم_الصنف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الصنف"), 1L, 1);

                    b.Property<string>("اسم_الصنف")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الاجمالي")
                        .HasColumnType("float");

                    b.Property<double>("السعر")
                        .HasColumnType("float");

                    b.Property<int>("الكميه")
                        .HasColumnType("int");

                    b.Property<double>("النهائي")
                        .HasColumnType("float");

                    b.Property<string>("وحده")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الصنف");

                    b.ToTable("بيع");
                });

            modelBuilder.Entity("FinalProjectDB.Models.شراء", b =>
                {
                    b.Property<int>("رقم_الصنف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الصنف"), 1L, 1);

                    b.Property<double>("ألنهائي")
                        .HasColumnType("float");

                    b.Property<string>("اسم_الصنف")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الاجمالي")
                        .HasColumnType("float");

                    b.Property<double>("السعر")
                        .HasColumnType("float");

                    b.Property<int>("الكميه")
                        .HasColumnType("int");

                    b.Property<string>("وحده")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الصنف");

                    b.ToTable("شراء");
                });

            modelBuilder.Entity("FinalProjectDB.Models.مرتجع_بيع", b =>
                {
                    b.Property<int>("رقم_الصنف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الصنف"), 1L, 1);

                    b.Property<double>("ألنهائي")
                        .HasColumnType("float");

                    b.Property<string>("اسم_الصنف")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الاجمالي")
                        .HasColumnType("float");

                    b.Property<double>("السعر")
                        .HasColumnType("float");

                    b.Property<int>("الكميه")
                        .HasColumnType("int");

                    b.Property<string>("وحده")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الصنف");

                    b.ToTable("مرتجع_بيع");
                });

            modelBuilder.Entity("FinalProjectDB.Models.مرتجع_شراء", b =>
                {
                    b.Property<int>("رقم_الصنف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الصنف"), 1L, 1);

                    b.Property<string>("اسم_الصنف")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الاجمالي")
                        .HasColumnType("float");

                    b.Property<double>("السعر")
                        .HasColumnType("float");

                    b.Property<int>("الكميه")
                        .HasColumnType("int");

                    b.Property<double>("النهائي")
                        .HasColumnType("float");

                    b.Property<string>("وحده")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الصنف");

                    b.ToTable("مرتجع_شراء");
                });

            modelBuilder.Entity("البضاعهالفواتير", b =>
                {
                    b.Property<int>("البضاعهرقم_الصنف")
                        .HasColumnType("int");

                    b.Property<int>("الفواتيررقم_الفاتوره")
                        .HasColumnType("int");

                    b.HasKey("البضاعهرقم_الصنف", "الفواتيررقم_الفاتوره");

                    b.HasIndex("الفواتيررقم_الفاتوره");

                    b.ToTable("البضاعهالفواتير");
                });

            modelBuilder.Entity("FinalProjectDB.Models.البضاعه", b =>
                {
                    b.HasOne("FinalProjectDB.Models.بيع", "بيع")
                        .WithMany()
                        .HasForeignKey("بيعرقم_الصنف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectDB.Models.شراء", "شراء")
                        .WithMany()
                        .HasForeignKey("شراءرقم_الصنف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectDB.Models.مرتجع_بيع", "مرتجع_بيع")
                        .WithMany()
                        .HasForeignKey("مرتجع_بيعرقم_الصنف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectDB.Models.مرتجع_شراء", "مرتجع_شراء")
                        .WithMany()
                        .HasForeignKey("مرتجع_شراءرقم_الصنف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("بيع");

                    b.Navigation("شراء");

                    b.Navigation("مرتجع_بيع");

                    b.Navigation("مرتجع_شراء");
                });

            modelBuilder.Entity("البضاعهالفواتير", b =>
                {
                    b.HasOne("FinalProjectDB.Models.البضاعه", null)
                        .WithMany()
                        .HasForeignKey("البضاعهرقم_الصنف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectDB.Models.الفواتير", null)
                        .WithMany()
                        .HasForeignKey("الفواتيررقم_الفاتوره")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
