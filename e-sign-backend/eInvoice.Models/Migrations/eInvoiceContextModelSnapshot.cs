﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eInvoice.Models.Models.DbContext;

namespace eInvoice.Models.Migrations
{
    [DbContext(typeof(eInvoiceContext))]
    partial class eInvoiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eInvoice.Models.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Approach")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("approach");

                    b.Property<string>("CountryOfOrigin")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("countryOfOrigin");

                    b.Property<string>("DateValidity")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("dateValidity");

                    b.Property<string>("ExportPort")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("exportPort");

                    b.Property<decimal?>("GrossWeight")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("grossWeight");

                    b.Property<decimal?>("NetWeight")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("netWeight");

                    b.Property<string>("Packaging")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("packaging");

                    b.Property<string>("Terms")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("terms");

                    b.HasKey("Id");

                    b.ToTable("Delivery", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Invoice", b =>
                {
                    b.Property<string>("InteranlId")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("interanlId");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("date")
                        .HasColumnName("dateIssued");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("deliveryId");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("documentType");

                    b.Property<string>("DocumentTypeversion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("documentTypeversion");

                    b.Property<decimal>("ExtraDiscountAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("extraDiscountAmount");

                    b.Property<int>("IssuerId")
                        .HasColumnType("int")
                        .HasColumnName("issuerId");

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("netAmount");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int")
                        .HasColumnName("paymentId");

                    b.Property<string>("ProformaInvoiceNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("proformaInvoiceNumber");

                    b.Property<string>("PurchaseOrderDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("purchaseOrderDescription");

                    b.Property<string>("PurchaseOrderReference")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("purchaseOrderReference");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int")
                        .HasColumnName("receiverId");

                    b.Property<string>("SalesOrderDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("salesOrderDescription");

                    b.Property<string>("SalesOrderReference")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("salesOrderReference");

                    b.Property<string>("TaxpayerActivityCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("taxpayerActivityCode");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("totalAmount");

                    b.Property<decimal>("TotalDiscountAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("totalDiscountAmount");

                    b.Property<decimal>("TotalItemsDiscountAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("totalItemsDiscountAmount");

                    b.Property<decimal>("TotalSalesAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("totalSalesAmount");

                    b.HasKey("InteranlId")
                        .HasName("PK__Invoice__1B0114ED4BCD0616");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("IssuerId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Invoice", "taxes");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Issuer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInformation")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("additionalInformation");

                    b.Property<string>("BranchId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("branchId");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("buildingNumber");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("country");

                    b.Property<string>("FlatNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("flatNumber");

                    b.Property<string>("Floor")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("floor");

                    b.Property<string>("Governate")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("governate");

                    b.Property<string>("Landmark")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("landmark");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("postalCode");

                    b.Property<decimal?>("PriceThreshold")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("priceThreshold");

                    b.Property<string>("RegionCity")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("regionCity");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("registrationNumber");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Issuer", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccountIban")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("bankAccountIBAN");

                    b.Property<string>("BankAccountNo")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("bankAccountNo");

                    b.Property<string>("BankAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("bankAddress");

                    b.Property<string>("BankName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("bankName");

                    b.Property<string>("SwiftCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("swiftCode");

                    b.Property<string>("Terms")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("terms");

                    b.HasKey("Id");

                    b.ToTable("Payments", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Product", b =>
                {
                    b.Property<int>("Productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("productid")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountEgp")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("amountEGP");

                    b.Property<decimal?>("AmountSold")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("amountSold");

                    b.Property<decimal>("CurrencyExchangeRate")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("currencyExchangeRate");

                    b.Property<string>("CurrencySold")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("currencySold");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<decimal?>("DiscountAmount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("discountAmount");

                    b.Property<decimal?>("DiscountRate")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("discountRate");

                    b.Property<decimal?>("InternalCode")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("internalCode");

                    b.Property<string>("InvoiceInternalId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("invoiceInternalId");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("itemCode");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("itemType");

                    b.Property<decimal>("ItemsDiscount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("itemsDiscount");

                    b.Property<decimal>("NetTotal")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("netTotal");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("quantity");

                    b.Property<decimal>("SalesTotal")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("salesTotal");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("total");

                    b.Property<decimal>("TotalTaxableFees")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("totalTaxableFees");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("unitType");

                    b.Property<decimal>("ValueDifference")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("valueDifference");

                    b.HasKey("Productid");

                    b.HasIndex("InvoiceInternalId");

                    b.ToTable("Products", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Receiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInformation")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("additionalInformation");

                    b.Property<string>("BranchId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("branchId");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("buildingNumber");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("country");

                    b.Property<string>("FlatNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("flatNumber");

                    b.Property<string>("Floor")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("floor");

                    b.Property<string>("Governate")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("governate");

                    b.Property<string>("Landmark")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("landmark");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("postalCode");

                    b.Property<string>("RegionCity")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("regionCity");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("registrationNumber");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Receiver", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Signature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InvoiceInternalId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("invoiceInternalId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceInternalId");

                    b.ToTable("Signatures", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.SubmittedDoc", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("InvoiceInternalId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("invoiceInternalId");

                    b.Property<string>("LongId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("longId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceInternalId");

                    b.ToTable("SubmittedDocs", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.TaxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("amount");

                    b.Property<string>("InvoiceInternalId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("invoiceInternalId");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(10,5)")
                        .HasColumnName("rate");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("subType");

                    b.Property<string>("TaxType1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("taxType");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceInternalId");

                    b.ToTable("TaxTypes", "taxes");
                });

            modelBuilder.Entity("eInvoice.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Usersdetail", b =>
                {
                    b.Property<int>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("userid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("country");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("firstName");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("fullAddress");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("fullName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("lastName");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.HasKey("Userid")
                        .HasName("PK__Usersdet__CBA1B2570CDC5B00");

                    b.ToTable("Usersdetails", "business");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Invoice", b =>
                {
                    b.HasOne("eInvoice.Models.Models.Delivery", "Delivery")
                        .WithMany("Invoices")
                        .HasForeignKey("DeliveryId")
                        .HasConstraintName("FK__Invoice__deliver__5DCAEF64")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eInvoice.Models.Models.Issuer", "Issuer")
                        .WithMany("Invoices")
                        .HasForeignKey("IssuerId")
                        .HasConstraintName("FK__Invoice__issuerI__5AEE82B9")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eInvoice.Models.Models.Payment", "Payment")
                        .WithMany("Invoices")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK__Invoice__payment__5CD6CB2B")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eInvoice.Models.Models.Receiver", "Receiver")
                        .WithMany("Invoices")
                        .HasForeignKey("ReceiverId")
                        .HasConstraintName("FK__Invoice__receive__5BE2A6F2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Issuer");

                    b.Navigation("Payment");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Product", b =>
                {
                    b.HasOne("eInvoice.Models.Models.Invoice", "InvoiceInternal")
                        .WithMany("Products")
                        .HasForeignKey("InvoiceInternalId")
                        .HasConstraintName("FK__Products__invoic__6383C8BA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceInternal");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Signature", b =>
                {
                    b.HasOne("eInvoice.Models.Models.Invoice", "InvoiceInternal")
                        .WithMany("Signatures")
                        .HasForeignKey("InvoiceInternalId")
                        .HasConstraintName("FK__Signature__invoi__66603565")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceInternal");
                });

            modelBuilder.Entity("eInvoice.Models.Models.SubmittedDoc", b =>
                {
                    b.HasOne("eInvoice.Models.Models.Invoice", "InvoiceInternal")
                        .WithMany("SubmittedDocs")
                        .HasForeignKey("InvoiceInternalId")
                        .HasConstraintName("FK__Submitted__invoi__60A75C0F")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceInternal");
                });

            modelBuilder.Entity("eInvoice.Models.Models.TaxType", b =>
                {
                    b.HasOne("eInvoice.Models.Models.Invoice", "InvoiceInternal")
                        .WithMany("TaxTypes")
                        .HasForeignKey("InvoiceInternalId")
                        .HasConstraintName("FK__TaxTypes__invoic__693CA210")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceInternal");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Usersdetail", b =>
                {
                    b.HasOne("eInvoice.Models.Models.User", "User")
                        .WithOne("Usersdetail")
                        .HasForeignKey("eInvoice.Models.Models.Usersdetail", "Userid")
                        .HasConstraintName("FK__Usersdeta__fullA__6E01572D")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Delivery", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Invoice", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Signatures");

                    b.Navigation("SubmittedDocs");

                    b.Navigation("TaxTypes");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Issuer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Payment", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("eInvoice.Models.Models.Receiver", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("eInvoice.Models.Models.User", b =>
                {
                    b.Navigation("Usersdetail");
                });
#pragma warning restore 612, 618
        }
    }
}
