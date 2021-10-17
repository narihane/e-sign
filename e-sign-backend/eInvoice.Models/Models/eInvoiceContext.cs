using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class eInvoiceContext : DbContext
    {
        public eInvoiceContext()
        {
        }

        public eInvoiceContext(DbContextOptions<eInvoiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Issuer> Issuers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<Signature> Signatures { get; set; }
        public virtual DbSet<SubmittedDoc> SubmittedDocs { get; set; }
        public virtual DbSet<TaxType> TaxTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Usersdetail> Usersdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=eInvoice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approach)
                    .HasMaxLength(255)
                    .HasColumnName("approach");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(255)
                    .HasColumnName("countryOfOrigin");

                entity.Property(e => e.DateValidity)
                    .HasMaxLength(255)
                    .HasColumnName("dateValidity");

                entity.Property(e => e.ExportPort)
                    .HasMaxLength(255)
                    .HasColumnName("exportPort");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("grossWeight");

                entity.Property(e => e.NetWeight)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("netWeight");

                entity.Property(e => e.Packaging)
                    .HasMaxLength(255)
                    .HasColumnName("packaging");

                entity.Property(e => e.Terms)
                    .HasMaxLength(255)
                    .HasColumnName("terms");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InteranlId)
                    .HasName("PK__Invoice__1B0114EDF4EDCF06");

                entity.ToTable("Invoice", "taxes");

                entity.Property(e => e.InteranlId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("interanlId");

                entity.Property(e => e.DateIssued)
                    .HasColumnType("date")
                    .HasColumnName("dateIssued");

                entity.Property(e => e.DeliveryId).HasColumnName("deliveryId");

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentType");

                entity.Property(e => e.DocumentTypeversion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentTypeversion");

                entity.Property(e => e.ExtraDiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("extraDiscountAmount");

                entity.Property(e => e.IssuerId).HasColumnName("issuerId");

                entity.Property(e => e.NetAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("netAmount");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.ProformaInvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("proformaInvoiceNumber");

                entity.Property(e => e.PurchaseOrderDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("purchaseOrderDescription");

                entity.Property(e => e.PurchaseOrderReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("purchaseOrderReference");

                entity.Property(e => e.ReceiverId).HasColumnName("receiverId");

                entity.Property(e => e.SalesOrderDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("salesOrderDescription");

                entity.Property(e => e.SalesOrderReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("salesOrderReference");

                entity.Property(e => e.TaxpayerActivityCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("taxpayerActivityCode");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalAmount");

                entity.Property(e => e.TotalDiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalDiscountAmount");

                entity.Property(e => e.TotalItemsDiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalItemsDiscountAmount");

                entity.Property(e => e.TotalSalesAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalSalesAmount");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Invoice__deliver__60A75C0F");

                entity.HasOne(d => d.Issuer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IssuerId)
                    .HasConstraintName("FK__Invoice__issuerI__5DCAEF64");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Invoice__payment__5FB337D6");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__Invoice__receive__5EBF139D");
            });

            modelBuilder.Entity<Issuer>(entity =>
            {
                entity.ToTable("Issuer", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInformation)
                    .HasMaxLength(255)
                    .HasColumnName("additionalInformation");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(255)
                    .HasColumnName("branchId");

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("buildingNumber");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.FlatNumber)
                    .HasMaxLength(255)
                    .HasColumnName("flatNumber");

                entity.Property(e => e.Floor)
                    .HasMaxLength(255)
                    .HasColumnName("floor");

                entity.Property(e => e.Governate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("governate");

                entity.Property(e => e.Landmark)
                    .HasMaxLength(255)
                    .HasColumnName("landmark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postalCode");

                entity.Property(e => e.PriceThreshold)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("priceThreshold");

                entity.Property(e => e.RegionCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("regionCity");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("registrationNumber");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankAccountIban)
                    .HasMaxLength(255)
                    .HasColumnName("bankAccountIBAN");

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(255)
                    .HasColumnName("bankAccountNo");

                entity.Property(e => e.BankAddress)
                    .HasMaxLength(255)
                    .HasColumnName("bankAddress");

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasColumnName("bankName");

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(255)
                    .HasColumnName("swiftCode");

                entity.Property(e => e.Terms)
                    .HasMaxLength(255)
                    .HasColumnName("terms");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "business");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("amountEGP");

                entity.Property(e => e.AmountSold)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("amountSold");

                entity.Property(e => e.CurrencyExchangeRate)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("currencyExchangeRate");

                entity.Property(e => e.CurrencySold)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("currencySold");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("discountAmount");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("discountRate");

                entity.Property(e => e.InternalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("internalCode");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("itemCode");

                entity.Property(e => e.ItemType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("itemType");

                entity.Property(e => e.ItemsDiscount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("itemsDiscount");

                entity.Property(e => e.NetTotal)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("netTotal");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("quantity");

                entity.Property(e => e.SalesTotal)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("salesTotal");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("total");

                entity.Property(e => e.TotalTaxableFees)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalTaxableFees");

                entity.Property(e => e.UnitType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("unitType");

                entity.Property(e => e.ValueDifference)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("valueDifference");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__Products__invoic__66603565");
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.ToTable("Receiver", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInformation)
                    .HasMaxLength(255)
                    .HasColumnName("additionalInformation");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(255)
                    .HasColumnName("branchId");

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("buildingNumber");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.FlatNumber)
                    .HasMaxLength(255)
                    .HasColumnName("flatNumber");

                entity.Property(e => e.Floor)
                    .HasMaxLength(255)
                    .HasColumnName("floor");

                entity.Property(e => e.Governate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("governate");

                entity.Property(e => e.Landmark)
                    .HasMaxLength(255)
                    .HasColumnName("landmark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postalCode");

                entity.Property(e => e.RegionCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("regionCity");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("registrationNumber");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Signature>(entity =>
            {
                entity.ToTable("Signatures", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.Signatures)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__Signature__invoi__693CA210");
            });

            modelBuilder.Entity<SubmittedDoc>(entity =>
            {
                entity.ToTable("SubmittedDocs", "business");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.LongId)
                    .HasMaxLength(255)
                    .HasColumnName("longId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.SubmittedDocs)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__Submitted__invoi__6383C8BA");
            });

            modelBuilder.Entity<TaxType>(entity =>
            {
                entity.ToTable("TaxTypes", "taxes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("amount");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.Rate)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("rate");

                entity.Property(e => e.SubType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("subType");

                entity.Property(e => e.TaxType1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("taxType");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.TaxTypes)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__TaxTypes__invoic__6C190EBB");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Usersdetail>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Usersdet__CBA1B257D818C674");

                entity.ToTable("Usersdetails", "business");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.FullAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullAddress");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Usersdetail)
                    .HasForeignKey<Usersdetail>(d => d.Userid)
                    .HasConstraintName("FK__Usersdeta__fullA__70DDC3D8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
