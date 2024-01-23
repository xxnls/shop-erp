﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopERP.Models.Contexts;

#nullable disable

namespace ShopERP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240122215751_ChangeShiftDateToDateTime")]
    partial class ChangeShiftDateToDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopERP.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .IsFixedLength();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StreetName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AddressId")
                        .HasName("PK__Addresse__091C2A1B5802DE56");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ShopERP.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("CountryName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.HasKey("CountryId")
                        .HasName("PK__Countrie__10D160BF23EAE6DE");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ShopERP.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("bit");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B813708BA0");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShopERP.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<string>("EmployeeFirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EmployeeRoleId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeRoleID");

                    b.Property<decimal?>("EmployeeSalary")
                        .HasColumnType("money");

                    b.Property<decimal?>("EmployeeWage")
                        .HasColumnType("money");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__7AD04FF1FD2681ED");

                    b.HasIndex("AddressId");

                    b.HasIndex("EmployeeRoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ShopERP.Models.EmployeeShift", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int")
                        .HasColumnName("ShiftID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId", "ShiftId")
                        .HasName("PK__Employee__76DACC7FAF0CF25E");

                    b.HasIndex("ShiftId");

                    b.ToTable("EmployeeShifts");
                });

            modelBuilder.Entity("ShopERP.Models.EmployeesRole", b =>
                {
                    b.Property<int>("EmployeeRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeRoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeRoleId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<string>("EmployeeRoleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("PermissionToDeleteData")
                        .HasColumnType("bit");

                    b.Property<bool>("PermissionToManageEmployees")
                        .HasColumnType("bit");

                    b.Property<bool>("PermissionToManageOrders")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeRoleId")
                        .HasName("PK__Employee__34618686CA911A73");

                    b.ToTable("EmployeesRoles");
                });

            modelBuilder.Entity("ShopERP.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EquipmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EquipmentAcquireDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("EquipmentBoughtPrice")
                        .HasColumnType("money");

                    b.Property<bool>("EquipmentIsLeased")
                        .HasColumnType("bit");

                    b.Property<string>("EquipmentLeasedFrom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EquipmentServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EquipmentId")
                        .HasName("PK__Equipmen__344745994C9DFCB8");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("ShopERP.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("OrderFinishDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("OrderTotalValue")
                        .HasColumnType("money");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAFF2DB85A2");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShopERP.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<decimal>("OrderProductPrice")
                        .HasColumnType("money");

                    b.Property<int>("OrderProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK__OrderDet__08D097C10E727B80");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ShopERP.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentMethodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentMethodId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsMethodStationary")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PaymentMethodId")
                        .HasName("PK__PaymentM__DC31C1F30683F13F");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("ShopERP.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("ProductCategoryID");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("money");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("int")
                        .HasColumnName("ProductUnitID");

                    b.HasKey("ProductId")
                        .HasName("PK__Products__B40CC6ED9A1CE63F");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopERP.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductCategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<int?>("DefaultExpirationMonths")
                        .HasColumnType("int");

                    b.Property<string>("ProductCategoryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ProductCategoryId")
                        .HasName("PK__ProductC__3224ECEEDAA6AF5E");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ShopERP.Models.ProductUnit", b =>
                {
                    b.Property<int>("ProductUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductUnitID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductUnitId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductUnitName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductUnitNameShort")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.HasKey("ProductUnitId")
                        .HasName("PK__ProductU__921B29E96D27F042");

                    b.ToTable("ProductUnits");
                });

            modelBuilder.Entity("ShopERP.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReviewID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .HasColumnType("text");

                    b.HasKey("ReviewId")
                        .HasName("PK__Reviews__74BC79AE076DC8A0");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ShopERP.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SaleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<double>("SaleDiscount")
                        .HasColumnType("float");

                    b.Property<DateTime>("SaleEndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SaleStartDate")
                        .HasColumnType("datetime");

                    b.HasKey("SaleId")
                        .HasName("PK__Sales__1EE3C41F06E6D949");

                    b.HasIndex("ProductId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("ShopERP.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShiftID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ShiftEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShiftStartTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("ShiftTotalHours")
                        .HasColumnType("float");

                    b.HasKey("ShiftId")
                        .HasName("PK__Shifts__C0A838E18B5D40C5");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("ShopERP.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SupplierID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateEdited")
                        .HasColumnType("datetime");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierId")
                        .HasName("PK__Supplier__4BE66694DF513EAB");

                    b.HasIndex("AddressId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ShopERP.Models.Address", b =>
                {
                    b.HasOne("ShopERP.Models.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK__Addresses__Count__68487DD7");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ShopERP.Models.Customer", b =>
                {
                    b.HasOne("ShopERP.Models.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK__Customers__Addre__6B24EA82");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ShopERP.Models.Employee", b =>
                {
                    b.HasOne("ShopERP.Models.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK__Employees__Addre__72C60C4A");

                    b.HasOne("ShopERP.Models.EmployeesRole", "EmployeeRole")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeRoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Employees__Emplo__71D1E811");

                    b.Navigation("Address");

                    b.Navigation("EmployeeRole");
                });

            modelBuilder.Entity("ShopERP.Models.EmployeeShift", b =>
                {
                    b.HasOne("ShopERP.Models.Employee", "Employee")
                        .WithMany("EmployeeShifts")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeS__Emplo__00200768");

                    b.HasOne("ShopERP.Models.Shift", "Shift")
                        .WithMany("EmployeeShifts")
                        .HasForeignKey("ShiftId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeS__Shift__01142BA1");

                    b.Navigation("Employee");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("ShopERP.Models.Order", b =>
                {
                    b.HasOne("ShopERP.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__Customer__787EE5A0");

                    b.HasOne("ShopERP.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__Employee__797309D9");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ShopERP.Models.OrderDetail", b =>
                {
                    b.HasOne("ShopERP.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Order__7C4F7684");

                    b.HasOne("ShopERP.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Produ__7D439ABD");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopERP.Models.Product", b =>
                {
                    b.HasOne("ShopERP.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Products__Produc__6E01572D");

                    b.HasOne("ShopERP.Models.ProductUnit", "ProductUnit")
                        .WithMany("Products")
                        .HasForeignKey("ProductUnitId")
                        .IsRequired()
                        .HasConstraintName("FK__Products__Produc__6EF57B66");

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("ShopERP.Models.Review", b =>
                {
                    b.HasOne("ShopERP.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__Custome__09A971A2");

                    b.HasOne("ShopERP.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__Reviews__Product__08B54D69");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopERP.Models.Sale", b =>
                {
                    b.HasOne("ShopERP.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__Sales__ProductID__03F0984C");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopERP.Models.Supplier", b =>
                {
                    b.HasOne("ShopERP.Models.Address", "Address")
                        .WithMany("Suppliers")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK__Suppliers__Addre__75A278F5");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ShopERP.Models.Address", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("ShopERP.Models.Country", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("ShopERP.Models.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ShopERP.Models.Employee", b =>
                {
                    b.Navigation("EmployeeShifts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ShopERP.Models.EmployeesRole", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ShopERP.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShopERP.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Reviews");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("ShopERP.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopERP.Models.ProductUnit", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopERP.Models.Shift", b =>
                {
                    b.Navigation("EmployeeShifts");
                });
#pragma warning restore 612, 618
        }
    }
}
