--CREATE Database eInvoice;
--GO

------ create schemas
--CREATE SCHEMA taxes;
--go

--CREATE SCHEMA business;
--go

-- create tables

CREATE TABLE business.Issuer (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	type VARCHAR (50) NOT NULL,
	registrationNumber NVARCHAR (255) NOT NULL,
	name NVARCHAR (255) NOT NULL,
	branchId NVARCHAR (255) NULL,
	country NVARCHAR (255) NULL,
	governate NVARCHAR (255) NOT NULL,
	regionCity NVARCHAR (255) NOT NULL,
	street NVARCHAR (255) NOT NULL,
	buildingNumber NVARCHAR (50) NOT NULL,
	postalCode NVARCHAR (255) NULL,
	floor NVARCHAR (255) NULL,
	flatNumber NVARCHAR (255) NULL,
	landmark NVARCHAR (255) NULL,
	priceThreshold DECIMAL (10,5) NULL,
	additionalInformation NVARCHAR (255) NULL,
);

CREATE TABLE business.Receiver (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	type VARCHAR (50) NOT NULL,
	registrationNumber NVARCHAR (255) NOT NULL,
	name NVARCHAR (255) NOT NULL,
	branchId NVARCHAR (255) NULL,
	country NVARCHAR (255) NULL,
	governate NVARCHAR (255) NOT NULL,
	regionCity NVARCHAR (255) NOT NULL,
	street NVARCHAR (255) NOT NULL,
	buildingNumber NVARCHAR (50) NOT NULL,
	postalCode NVARCHAR (255) NULL,
	floor NVARCHAR (255) NULL,
	flatNumber NVARCHAR (255) NULL,
	landmark NVARCHAR (255) NULL,
	additionalInformation NVARCHAR (255) NULL,
);

CREATE TABLE business.Payments (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	bankName NVARCHAR (255) NULL,
	bankAddress NVARCHAR (255) NULL,
	bankAccountNo NVARCHAR (255) NULL,
	bankAccountIBAN NVARCHAR (255) NULL,
	swiftCode NVARCHAR (255) NULL,
	terms NVARCHAR (255) NULL,
);

CREATE TABLE business.Delivery (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	approach NVARCHAR (255) NULL,
	packaging NVARCHAR (255) NULL,
	dateValidity NVARCHAR (255) NULL,
	exportPort NVARCHAR (255) NULL,
	countryOfOrigin NVARCHAR (255) NULL,
	grossWeight DECIMAL (10,5) NULL,
	netWeight DECIMAL (10,5) NULL,
	terms NVARCHAR (255) NULL,
);

CREATE TABLE taxes.Invoice (
    interanlId VARCHAR(255) NOT NULL PRIMARY KEY,
	issuerId INT NOT NULL,
	receiverId INT NOT NULL,
	documentType VARCHAR (50) NOT NULL,
	documentTypeversion VARCHAR (50) NOT NULL,
	dateIssued DATE NOT NULL,
	purchaseOrderReference VARCHAR(255) NULL,
	purchaseOrderDescription VARCHAR(255) NULL,
	salesOrderReference VARCHAR(255) NULL,
	salesOrderDescription VARCHAR(255) NULL,
	proformaInvoiceNumber VARCHAR(50) NULL,
	paymentId INT NULL,
	deliveryId INT NULL,
	totalSalesAmount Decimal(20,5) NOT NULL,
	totalDiscountAmount Decimal(20,5) NOT NULL,
	netAmount Decimal(20,5) NOT NULL,
	extraDiscountAmount Decimal(20,5) NOT NULL,
	totalItemsDiscountAmount Decimal(20,5) NOT NULL,
	totalAmount Decimal(20,5) NOT NULL,
	taxpayerActivityCode VARCHAR(255) NOT NULL,
	FOREIGN KEY (issuerId) REFERENCES business.Issuer (id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (receiverId) REFERENCES business.Receiver (id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (paymentId) REFERENCES business.payments (id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (deliveryId) REFERENCES business.delivery (id) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE business.SubmittedDocs (
	id NVARCHAR (255) NOT NULL PRIMARY KEY,
	status VARCHAR (50) NOT NULL,
	longId NVARCHAR (255) NULL,
	invoiceInternalId VARCHAR (255) NOT NULL
	FOREIGN KEY (invoiceInternalId) REFERENCES taxes.invoice (interanlId) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE business.Products (
	productid INT IDENTITY (1, 1) PRIMARY KEY,
	invoiceInternalId VARCHAR(255) NOT NULL,
	description VARCHAR(255) NOT NULL,
	itemType VARCHAR(255) NOT NULL,
	itemCode VARCHAR(255) NOT NULL,
	unitType VARCHAR(255) NOT NULL,
	quantity Decimal(20,5) NOT NULL,
	currencySold VARCHAR(255) NOT NULL,
	amountEGP Decimal(20,5) NOT NULL,
	amountSold Decimal(20,5) NULL,
	currencyExchangeRate Decimal(20,5) NULL,
	salesTotal Decimal(20,5) NOT NULL,
	total Decimal(20,5) NOT NULL,
	valueDifference Decimal(20,5) NOT NULL,
	totalTaxableFees Decimal(20,5) NOT NULL,
	netTotal Decimal(20,5) NOT NULL,
	itemsDiscount Decimal(20,5) NOT NULL,
	discountRate Decimal(20,5) NULL,
	discountAmount Decimal(20,5) NULL,
	internalCode VARCHAR(255) NULL,
	FOREIGN KEY (invoiceInternalId) REFERENCES taxes.invoice (interanlId) ON DELETE CASCADE ON UPDATE CASCADE,
);


CREATE TABLE business.Signatures (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	type VARCHAR (50) NOT NULL,
	value NVARCHAR (MAX) NOT NULL,
	invoiceInternalId VARCHAR(255) NOT NULL,
	FOREIGN KEY (invoiceInternalId) REFERENCES taxes.invoice (interanlId) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE taxes.TaxTypes (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	taxType NVARCHAR (255) NOT NULL,
	amount DECIMAL (10,5) NOT NULL,
	subType NVARCHAR (255) NOT NULL,
	rate DECIMAL (20,5) NOT NULL,
	invoiceInternalId VARCHAR(255) NOT NULL,
	FOREIGN KEY (invoiceInternalId) REFERENCES taxes.invoice (interanlId) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE business.Users (
	id INT IDENTITY (1, 1) PRIMARY KEY,
	username VARCHAR (255) NOT NULL,
	password VARCHAR (255) NOT NULL,
	role VARCHAR (50) NOT NULL,
);

CREATE TABLE business.Usersdetails (
	userid INT PRIMARY KEY,
	firstName VARCHAR (255) NOT NULL,
	lastName VARCHAR (255) NOT NULL,
	fullName VARCHAR (255) NOT NULL,
	phone VARCHAR (25) NOT NULL,
	email VARCHAR (255) NOT NULL,
	street VARCHAR (255) NOT NUll,
	city VARCHAR (50) NOT NULL,
	country VARCHAR (25) NOT NULL,
	fullAddress VARCHAR (255) NOT NULL
	FOREIGN KEY (userid) REFERENCES business.users (id) ON DELETE CASCADE ON UPDATE CASCADE,
);