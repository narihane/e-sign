using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInvoice.Models.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "business");

            migrationBuilder.EnsureSchema(
                name: "taxes");

            migrationBuilder.CreateTable(
                name: "company",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    registrationNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    branchId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    governate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    regionCity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    buildingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    postalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    floor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    flatNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    landmark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    additionalInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    approach = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    packaging = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dateValidity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    exportPort = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    countryOfOrigin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    grossWeight = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    netWeight = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    terms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bankName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bankAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bankAccountNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bankAccountIBAN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    swiftCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    terms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                schema: "taxes",
                columns: table => new
                {
                    interanlId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    documentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    documentTypeversion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    dateIssued = table.Column<DateTime>(type: "date", nullable: false),
                    purchaseOrderReference = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    purchaseOrderDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salesOrderReference = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salesOrderDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    proformaInvoiceNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    paymentId = table.Column<int>(type: "int", nullable: true),
                    deliveryId = table.Column<int>(type: "int", nullable: true),
                    totalSalesAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    totalDiscountAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    netAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    extraDiscountAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    totalItemsDiscountAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    totalAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invoice__1B0114ED32D54757", x => x.interanlId);
                    table.ForeignKey(
                        name: "FK__invoice__company__2A4B4B5E",
                        column: x => x.companyId,
                        principalSchema: "business",
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__invoice__deliver__2C3393D0",
                        column: x => x.deliveryId,
                        principalSchema: "business",
                        principalTable: "delivery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__invoice__payment__2B3F6F97",
                        column: x => x.paymentId,
                        principalSchema: "business",
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usersdetails",
                schema: "business",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fullName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    fullAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usersdet__CBA1B257BAC2A7B9", x => x.userid);
                    table.ForeignKey(
                        name: "FK__usersdeta__fullA__5070F446",
                        column: x => x.userid,
                        principalSchema: "business",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "business",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceInternalId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    itemType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    itemCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    unitType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    currencySold = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    amountEGP = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    amountSold = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    currencyExchangeRate = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    salesTotal = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    valueDifference = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    totalTaxableFees = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    netTotal = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    itemsDiscount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    discountRate = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    discountAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    internalCode = table.Column<decimal>(type: "decimal(10,5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productid);
                    table.ForeignKey(
                        name: "FK__products__invoic__31EC6D26",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "signatures",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    invoiceInternalId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signatures", x => x.id);
                    table.ForeignKey(
                        name: "FK__signature__invoi__34C8D9D1",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "submittedDocs",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    longId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    invoiceInternalId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submittedDocs", x => x.id);
                    table.ForeignKey(
                        name: "FK__submitted__invoi__2F10007B",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taxTypes",
                schema: "taxes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    subType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    rate = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    invoiceInternalId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK__taxTypes__invoic__37A5467C",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_companyId",
                schema: "taxes",
                table: "invoice",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_deliveryId",
                schema: "taxes",
                table: "invoice",
                column: "deliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_paymentId",
                schema: "taxes",
                table: "invoice",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_products_invoiceInternalId",
                schema: "business",
                table: "products",
                column: "invoiceInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_signatures_invoiceInternalId",
                schema: "business",
                table: "signatures",
                column: "invoiceInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_submittedDocs_invoiceInternalId",
                schema: "business",
                table: "submittedDocs",
                column: "invoiceInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_taxTypes_invoiceInternalId",
                schema: "taxes",
                table: "taxTypes",
                column: "invoiceInternalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products",
                schema: "business");

            migrationBuilder.DropTable(
                name: "signatures",
                schema: "business");

            migrationBuilder.DropTable(
                name: "submittedDocs",
                schema: "business");

            migrationBuilder.DropTable(
                name: "taxTypes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "usersdetails",
                schema: "business");

            migrationBuilder.DropTable(
                name: "invoice",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "users",
                schema: "business");

            migrationBuilder.DropTable(
                name: "company",
                schema: "business");

            migrationBuilder.DropTable(
                name: "delivery",
                schema: "business");

            migrationBuilder.DropTable(
                name: "payments",
                schema: "business");
        }
    }
}
