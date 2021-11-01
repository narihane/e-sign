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

        public virtual DbSet<CodeTemplate> CodeTemplates { get; set; }
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

            modelBuilder.Entity<CodeTemplate>(entity =>
            {
                entity.ToTable("CodeTemplates", "business");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.FileType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CodeTemplate>(entity =>
            {
                entity.ToTable("CodeTemplates", "business");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.FileType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            var CodeUsageBulkTemplateBytes = Convert.FromBase64String("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");


            modelBuilder.Entity<CodeTemplate>().HasData(new CodeTemplate { Id = Guid.Parse("29f0a6e2-b4ad-4e83-911f-b7427421cbb2"), FileName = "CodeUsageBulkTemplate.xlsx", FileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", File = CodeUsageBulkTemplateBytes });

            var NewCodeBulkTemplateBytes = Convert.FromBase64String("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");

            modelBuilder.Entity<CodeTemplate>().HasData(new CodeTemplate { Id = Guid.Parse("c1661cea-caa8-445f-9d03-35c8eea6fcb3"), FileName = "NewCodeBulkTemplate.xlsx", FileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", File = NewCodeBulkTemplateBytes });

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
                    .HasName("PK__Invoice__1B0114ED61A5BE0B");

                entity.ToTable("Invoice", "taxes");

                entity.HasIndex(e => e.DeliveryId, "IX_Invoice_deliveryId");

                entity.HasIndex(e => e.IssuerId, "IX_Invoice_issuerId");

                entity.HasIndex(e => e.PaymentId, "IX_Invoice_paymentId");

                entity.HasIndex(e => e.ReceiverId, "IX_Invoice_receiverId");

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
                    .HasConstraintName("FK__Invoice__deliver__32E0915F");

                entity.HasOne(d => d.Issuer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IssuerId)
                    .HasConstraintName("FK__Invoice__issuerI__300424B4");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Invoice__payment__31EC6D26");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__Invoice__receive__30F848ED");
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

                entity.HasIndex(e => e.InvoiceInternalId, "IX_Products_invoiceInternalId");

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
                    .HasConstraintName("FK__Products__invoic__38996AB5");
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

                entity.HasIndex(e => e.InvoiceInternalId, "IX_Signatures_invoiceInternalId");

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
                    .HasConstraintName("FK__Signature__invoi__3B75D760");
            });

            modelBuilder.Entity<SubmittedDoc>(entity =>
            {
                entity.ToTable("SubmittedDocs", "business");

                entity.HasIndex(e => e.InvoiceInternalId, "IX_SubmittedDocs_invoiceInternalId");

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
                    .HasConstraintName("FK__Submitted__invoi__35BCFE0A");
            });

            modelBuilder.Entity<TaxType>(entity =>
            {
                entity.ToTable("TaxTypes", "taxes");

                entity.HasIndex(e => e.InvoiceInternalId, "IX_TaxTypes_invoiceInternalId");

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
                    .HasConstraintName("FK__TaxTypes__invoic__3E52440B");
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
                    .HasColumnType("int")
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Status)
                    .IsRequired(false)
                    .HasColumnType("int")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Usersdetail>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Usersdet__CBA1B25706F63767");

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
                    .HasConstraintName("FK__Usersdeta__fullA__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
