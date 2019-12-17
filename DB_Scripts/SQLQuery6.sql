USE GuildCars_Aniket
GO

EXECUTE DbReset


SELECT TOP 20 VehicleId, VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, mk.MakeName as Make, mo.ModelName as Model, [Year] 
FROM Vehicle v 
INNER JOIN Make mk ON v.MakeId = mk.MakeId 
INNER JOIN Model mo ON v.ModelId = mo.ModelId 
WHERE Sold = 'true' and Type = 'Used'


SELECT * FROM SaleLog
WHERE PurchaseDate  BETWEEN  '2010/01/01' AND '2019/12/12'

SELECT FirstName + ' ' + LastName as [User], SUM(PurchasePrice) AS 'TotalSales', COUNT(SalesUserId) AS 'TotalVehicles' 
FROM SaleLog s INNER JOIN AspNetUsers u
ON s.SalesUserId = u.Id
GROUP BY FirstName, LastName


SELECT [Year], m.MakeName as Make, mo.ModelName as Model, COUNT(MSRP) as [Count] , SUM(MSRP) as 'StockValue'
FROM Vehicle v INNER JOIN Make m ON v.MakeId = m.MakeId
INNER JOIN Model mo ON v.ModelId = mo.ModelId
GROUP BY m.MakeName, mo.ModelName, [Year]

DELETE FROM Special WHERE SpecialId = 6

DELETE FROM AspNetUsers WHERE UserName = 'admin'

Select * from Special

SELECT * FROM model

SELECT * FROM AspNetUserRoles

SELECT * FROM AspNetUsers

SELECT * FROM AspNetRoles

DELETE FROM Make

SET IDENTITY_INSERT Make ON;

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 1, 'BMW', '10-04-2001', Id FROM AspNetUsers WHERE UserName = 'admin'

SET IDENTITY_INSERT Make OFF;