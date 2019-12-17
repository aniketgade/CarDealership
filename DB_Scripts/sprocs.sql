USE GuildCars_Aniket
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetFeaturedVehicleList')
DROP PROCEDURE GetFeaturedVehicleList
GO

CREATE PROCEDURE GetFeaturedVehicleList AS
BEGIN
	SELECT VehicleId, SalePrice, mk.MakeName as [Make], mo.ModelName as Model, [Year], ImageFileName
	FROM Vehicle v 
	INNER JOIN Make mk ON v.MakeId = mk.MakeId
	INNER JOIN Model mo ON v.ModelId = mo.ModelId
	 WHERE FeaturedVehicle = 1 AND Sold = 'false'
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetVehicleDetailsList')
DROP PROCEDURE GetVehicleDetailsList
GO

CREATE PROCEDURE GetVehicleDetailsList AS
BEGIN
	SELECT VehicleId, VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, [Description],  Make.MakeName as Make, Model.ModelName as Model, [Year]
	FROM Vehicle v
	INNER JOIN Make ON v.MakeId = Make.MakeId
	INNER JOIN Model ON v.ModelId = Model.ModelId
	WHERE Sold = 'false'
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetVehicleSearchResultList')
DROP PROCEDURE GetVehicleSearchResultList
GO

CREATE PROCEDURE GetVehicleSearchResultList(
@Type varchar(4)
) AS
BEGIN
	SELECT VehicleId, VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, Make.MakeName as Make, Model.ModelName as Model, [Year]
	FROM Vehicle v
	INNER JOIN Make ON v.MakeId = Make.MakeId
	INNER JOIN Model ON v.ModelId = Model.ModelId
	WHERE Type = @Type AND Sold = 'false'
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetVehicleById')
DROP PROCEDURE GetVehicleById
GO

CREATE PROCEDURE GetVehicleById(
 @VehicleId int
)AS
BEGIN
	SELECT VehicleId, VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, Make.MakeName as Make, Model.ModelName as Model, [Year], FeaturedVehicle, [Description], [Type], ImageFileName 
	FROM Vehicle v
	INNER JOIN Make ON v.MakeId = Make.MakeId
	INNER JOIN Model ON v.ModelId = Model.ModelId
	WHERE VehicleId = @VehicleId AND Sold = 'false'
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetSpecials')
DROP PROCEDURE GetSpecials
GO

CREATE PROCEDURE GetSpecials AS
BEGIN
	SELECT SpecialId, Title, [Description]
	FROM Special
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddContact')
DROP PROCEDURE AddContact
GO

CREATE PROCEDURE AddContact(
	@Name varchar(50),
	@Email nvarchar(100),
	@Phone nchar(10),
	@Message varchar(500)
) AS
BEGIN
	INSERT INTO Contact ([Name], Email, Phone, [Message])
	VALUES (@Name, @Email, @Phone, @Message);
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddSaleLog')
DROP PROCEDURE AddSaleLog
GO

CREATE PROCEDURE AddSaleLog(
	@BuyerName varchar(50),
	@Email varchar(50),
	@Street1 varchar(50),
	@Street2 varchar(50),
	@City varchar(45),
	@State char(2),
	@ZipCode char(5),
	@PurchasePrice money,
	@PurchaseType varchar(14),
	@VehicleId int,
	@Phone char(10),
	@SalesUserId nvarchar(128),
	@PurchaseDate datetime2(7)
) AS
BEGIN
	INSERT INTO SaleLog (BuyerName, Email, Street1, Street2, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
	VALUES (@BuyerName, @Email, @Street1, @Street2, @City, @State, @ZipCode, @PurchasePrice, @PurchaseType, @VehicleId, @Phone, @SalesUserId, @PurchaseDate);
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddVehicle')
DROP PROCEDURE AddVehicle
GO

CREATE PROCEDURE AddVehicle(
	@VehicleId int output,
	@VIN varchar(50),
	@Interior char(17),
	@Transmission varchar(9),
	@Mileage varchar(16),
	@MSRP money,
	@SalePrice money,
	@Color varchar(20),
	@BodyStyle varchar(10),
	@Description varchar(400),
	@Make varchar(15),
	@Model varchar(100),
	@Type varchar(10),
	@Year smallint
) AS
BEGIN
	-- First get the MakeId and ModelId from Make and Model tables, then use that in Insert statement
	DECLARE @MakeId int
	DECLARE @ModelId int

	SELECT @MakeId = MakeId 
	FROM Make where MakeName = @Make

	SELECT @ModelId = ModelId 
	FROM Model where ModelName = @Model

	INSERT INTO Vehicle(VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, [Description], MakeId, ModelId, [Type], [Year])
	VALUES (@VIN, @Interior, @Transmission, @Mileage, @MSRP, @SalePrice, @Color, @BodyStyle, @Description, @MakeId, @ModelId, @Type, @Year);

	SET @VehicleId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='DeleteVehicle')
DROP PROCEDURE DeleteVehicle
GO

CREATE PROCEDURE DeleteVehicle(
	@VehicleId int
	)
	AS
BEGIN
	
	DELETE FROM Vehicle WHERE VehicleId = @VehicleId

END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='UpdateVehicle')
DROP PROCEDURE UpdateVehicle
GO

CREATE PROCEDURE UpdateVehicle(
	@VehicleId int,
	@VIN varchar(50),
	@Interior char(17),
	@Transmission varchar(9),
	@Mileage varchar(16),
	@MSRP money,
	@SalePrice money,
	@Color varchar(20),
	@BodyStyle varchar(10),
	@Description varchar(400),
	@Make varchar(15),
	@Model varchar(100),
	@Type varchar(10),
	@Year smallint,
	@FeaturedVehicle bit
) AS
BEGIN
	-- First get the MakeId and ModelId from Make and Model tables, then use that in Insert statement
	DECLARE @MakeId int
	DECLARE @ModelId int

	SELECT @MakeId = MakeId 
	FROM Make where MakeName = @Make

	SELECT @ModelId = ModelId 
	FROM Model where ModelName = @Model

	UPDATE Vehicle
	SET VIN = @VIN, Interior = @Interior, Transmission = @Transmission, Mileage = @Mileage, MSRP = @MSRP, SalePrice = @SalePrice, Color = @Color, BodyStyle = @BodyStyle, [Description] = @Description, MakeId = @MakeId, ModelId = @ModelId, [Type] = @Type, [Year] = @Year, FeaturedVehicle = @FeaturedVehicle
	WHERE VehicleId = @VehicleId

END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddVehicleFileName')
DROP PROCEDURE AddVehicleFileName
GO

CREATE PROCEDURE AddVehicleFileName(
	@VehicleId int output,
	@ImageFileName nvarchar(50)
) AS
BEGIN

	UPDATE Vehicle
	SET ImageFileName = @ImageFileName
	WHERE VehicleId = @VehicleId;

END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='VehicleMarkPurchased')
DROP PROCEDURE VehicleMarkPurchased
GO

CREATE PROCEDURE VehicleMarkPurchased(
	@VehicleId int output
) AS
BEGIN

	UPDATE Vehicle
	SET Sold = 'true'
	WHERE VehicleId = @VehicleId;

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddModel')
DROP PROCEDURE AddModel
GO

CREATE PROCEDURE AddModel(
	@ModelName varchar(100),
	@MakeId smallint,
	@DateAdded datetime2(7),
	@UserId nvarchar(128)
) AS
BEGIN
	INSERT INTO Model (ModelName, MakeId, DateAdded, UserId)
	VALUES (@ModelName, @MakeId, @DateAdded, @UserId);
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddMake')
DROP PROCEDURE AddMake
GO

CREATE PROCEDURE AddMake(
	@MakeName varchar(15),
	@DateAdded datetime2(7),
	@UserId nvarchar(128)
) AS
BEGIN
	INSERT INTO Make (MakeName, DateAdded, UserId)
	VALUES (@MakeName, @DateAdded, @UserId);
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetUserList')
DROP PROCEDURE GetUserList
GO

CREATE PROCEDURE GetUserList AS
BEGIN
	SELECT LastName, FirstName, Email, r.Name as Role
FROM AspNetUsers u
INNER JOIN AspNetUserRoles ur ON u.Id = ur.UserId
INNER JOIN AspNetRoles r ON r.Id = ur.RoleId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetUserSaleList')
DROP PROCEDURE GetUserSaleList
GO

CREATE PROCEDURE GetUserSaleList AS
BEGIN
	SELECT FirstName + ' ' + LastName as [User], SUM(PurchasePrice) AS 'TotalSales', COUNT(SalesUserId) AS 'TotalVehicles' 
FROM SaleLog s INNER JOIN AspNetUsers u
ON s.SalesUserId = u.Id
GROUP BY FirstName, LastName
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetVehicleInventoryList')
DROP PROCEDURE GetVehicleInventoryList
GO

CREATE PROCEDURE GetVehicleInventoryList(
	@Type varchar(4)
)
AS
BEGIN
SELECT [Year], m.MakeName as Make, mo.ModelName as Model, COUNT(MSRP) as [Count] , SUM(MSRP) as 'StockValue'
FROM Vehicle v INNER JOIN Make m ON v.MakeId = m.MakeId
INNER JOIN Model mo ON v.ModelId = mo.ModelId
WHERE Type = @Type AND Sold = 'false'
GROUP BY m.MakeName, mo.ModelName, [Year]
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='AddSpecial')
DROP PROCEDURE AddSpecial
GO

CREATE PROCEDURE AddSpecial(
	@Title varchar(50),
	@Description nchar(500)
) AS
BEGIN
	INSERT INTO Special(Title, [Description])
	VALUES (@Title, @Description);
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='DeleteSpecial')
DROP PROCEDURE DeleteSpecial
GO

CREATE PROCEDURE DeleteSpecial(
	@SpecialId int
	)
	AS
BEGIN
	
	DELETE FROM Special WHERE SpecialId = @SpecialId

END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetMakeById')
DROP PROCEDURE GetMakeById
GO

CREATE PROCEDURE GetMakeById(
	@MakeId smallint
) 
AS
BEGIN
	SELECT MakeName
	FROM Make WHERE MakeId = @MakeId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetMakeIdByName')
DROP PROCEDURE GetMakeIdByName
GO

CREATE PROCEDURE GetMakeIdByName(
	@MakeName varchar(15)
) 
AS
BEGIN
	SELECT MakeId
	FROM Make WHERE MakeName = @MakeName
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetMakeNames')
DROP PROCEDURE GetMakeNames
GO

CREATE PROCEDURE GetMakeNames AS
BEGIN
	SELECT MakeName
	FROM Make 
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetMakeDetails')
DROP PROCEDURE GetMakeDetails
GO

CREATE PROCEDURE GetMakeDetails AS
BEGIN
	SELECT MakeId, MakeName, DateAdded, u.Email as UserEmail
	FROM Make m INNER JOIN AspNetUsers u
	ON m.UserId = u.Id
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetModelById')
DROP PROCEDURE GetModelById
GO

CREATE PROCEDURE GetModelById(
	@ModelId smallint
) 
AS
BEGIN
	SELECT ModelName
	FROM Model WHERE ModelId = @ModelId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetModelNames')
DROP PROCEDURE GetModelNames
GO

CREATE PROCEDURE GetModelNames AS
BEGIN
	SELECT ModelName
	FROM Model 
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetAllModelDetails')
DROP PROCEDURE GetAllModelDetails
GO

CREATE PROCEDURE GetAllModelDetails AS
BEGIN
	SELECT ModelName, mk.MakeName as MakeName, mk.MakeId as MakeId, mo.DateAdded as DateAdded, u.Email as UserEmail
	FROM Model mo INNER JOIN Make mk
	ON mo.MakeId = mk.MakeId
	INNER JOIN AspNetUsers u
	ON mo.UserId = u.Id
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='GetModelsByMake')
DROP PROCEDURE GetModelsByMake
GO

CREATE PROCEDURE GetModelsByMake (
	@MakeName varchar(15)
) AS
BEGIN
	SELECT ModelName
	FROM Model
	INNER JOIN Make ON Model.MakeId = Make.MakeId
	WHERE Make.MakeName = @MakeName
END
GO