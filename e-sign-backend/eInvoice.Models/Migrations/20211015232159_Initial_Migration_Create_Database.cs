using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eInvoice.Models.Migrations
{
    public partial class Initial_Migration_Create_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "business");

            migrationBuilder.EnsureSchema(
                name: "taxes");

            migrationBuilder.CreateTable(
                name: "Delivery",
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
                    table.PrimaryKey("PK_Delivery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Issuer",
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
                    priceThreshold = table.Column<decimal>(type: "decimal(10,5)", nullable: true),
                    additionalInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
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
                    table.PrimaryKey("PK_Payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Receiver",
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
                    table.PrimaryKey("PK_Receiver", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "taxes",
                columns: table => new
                {
                    interanlId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    issuerId = table.Column<int>(type: "int", nullable: false),
                    receiverId = table.Column<int>(type: "int", nullable: false),
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
                    totalAmount = table.Column<decimal>(type: "decimal(10,5)", nullable: false),
                    taxpayerActivityCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Invoice__1B0114ED4BCD0616", x => x.interanlId);
                    table.ForeignKey(
                        name: "FK__Invoice__deliver__5DCAEF64",
                        column: x => x.deliveryId,
                        principalSchema: "business",
                        principalTable: "Delivery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Invoice__issuerI__5AEE82B9",
                        column: x => x.issuerId,
                        principalSchema: "business",
                        principalTable: "Issuer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Invoice__payment__5CD6CB2B",
                        column: x => x.paymentId,
                        principalSchema: "business",
                        principalTable: "Payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Invoice__receive__5BE2A6F2",
                        column: x => x.receiverId,
                        principalSchema: "business",
                        principalTable: "Receiver",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usersdetails",
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
                    table.PrimaryKey("PK__Usersdet__CBA1B2570CDC5B00", x => x.userid);
                    table.ForeignKey(
                        name: "FK__Usersdeta__fullA__6E01572D",
                        column: x => x.userid,
                        principalSchema: "business",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                    table.PrimaryKey("PK_Products", x => x.productid);
                    table.ForeignKey(
                        name: "FK__Products__invoic__6383C8BA",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "Invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
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
                    table.PrimaryKey("PK_Signatures", x => x.id);
                    table.ForeignKey(
                        name: "FK__Signature__invoi__66603565",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "Invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedDocs",
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
                    table.PrimaryKey("PK_SubmittedDocs", x => x.id);
                    table.ForeignKey(
                        name: "FK__Submitted__invoi__60A75C0F",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "Invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
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
                    table.PrimaryKey("PK_TaxTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK__TaxTypes__invoic__693CA210",
                        column: x => x.invoiceInternalId,
                        principalSchema: "taxes",
                        principalTable: "Invoice",
                        principalColumn: "interanlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_deliveryId",
                schema: "taxes",
                table: "Invoice",
                column: "deliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_issuerId",
                schema: "taxes",
                table: "Invoice",
                column: "issuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_paymentId",
                schema: "taxes",
                table: "Invoice",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_receiverId",
                schema: "taxes",
                table: "Invoice",
                column: "receiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_invoiceInternalId",
                schema: "business",
                table: "Products",
                column: "invoiceInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_invoiceInternalId",
                schema: "business",
                table: "Signatures",
                column: "invoiceInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedDocs_invoiceInternalId",
                schema: "business",
                table: "SubmittedDocs",
                column: "invoiceInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypes_invoiceInternalId",
                schema: "taxes",
                table: "TaxTypes",
                column: "invoiceInternalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Signatures",
                schema: "business");

            migrationBuilder.DropTable(
                name: "SubmittedDocs",
                schema: "business");

            migrationBuilder.DropTable(
                name: "TaxTypes",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "Usersdetails",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Delivery",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Issuer",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Receiver",
                schema: "business");
        }
    }
}
