USE GuildCars_Aniket
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
DROP TABLE Contact
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Special')
DROP TABLE Special
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='SaleLog')
DROP TABLE SaleLog
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
DROP TABLE Make
GO



CREATE TABLE Contact(
	ContactId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Email nvarchar(100) NULL,
	Phone nchar(10) NULL,
	Message varchar(500) NOT NULL
	)
GO

CREATE TABLE Make(
	MakeId smallint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	MakeName varchar(15) NOT NULL,
	DateAdded datetime2(7) NOT NULL,
	UserId nvarchar(128) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id)
	)

CREATE TABLE Model(
	ModelId smallint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ModelName varchar(100) NOT NULL,
	MakeId smallint NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	DateAdded datetime2(7) NOT NULL,
	UserId nvarchar(128) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id)
	)
GO
 

CREATE TABLE Special(
	SpecialId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Title varchar(50) NOT NULL,
	Description nchar(500) NOT NULL
	)
GO 

CREATE TABLE Vehicle(
	VehicleId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	VIN varchar(50) NOT NULL,
	Interior char(17) NOT NULL,
	Transmission varchar(9) NOT NULL,
	Mileage int NOT NULL,
	MSRP money NOT NULL,
	SalePrice money NOT NULL,
	Color varchar(20) NOT NULL,
	BodyStyle varchar(10) NOT NULL,
	[Description] varchar(400) NOT NULL,
	MakeId smallint NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	ModelId smallint NOT NULL FOREIGN KEY REFERENCES Model(ModelId),
	[Year] smallint NOT NULL,
	Sold bit NOT NULL DEFAULT 0,
	FeaturedVehicle bit NOT NULL DEFAULT 0,
	Type varchar(4) NOT NULL,
	ImageFileName nvarchar(50) NULL
	)
GO 
	
	CREATE TABLE SaleLog(
	SaleId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	BuyerName varchar(50) NOT NULL,
	Email varchar(50) NULL,
	Street1 varchar(50) NOT NULL,
	Street2 varchar(50) NULL,
	City varchar(45) NOT NULL,
	[State] char(2) NOT NULL,
	ZipCode char(5) NOT NULL,
	PurchasePrice money NOT NULL,
	PurchaseType varchar(14) NOT NULL,
	VehicleId int NOT NULL FOREIGN KEY REFERENCES Vehicle(VehicleId),
	Phone char(10) NULL,
	SalesUserId nvarchar(128) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
	PurchaseDate datetime2(7) NULL
	)
GO