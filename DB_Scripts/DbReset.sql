USE GuildCars_Aniket
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_NAME='DbReset')
DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN

DELETE FROM SaleLog;
DELETE FROM Vehicle;
DELETE FROM Model;
DELETE FROM Make;
DELETE FROM Special;



DBCC CHECKIDENT ('Make',RESEED, 1)

SET IDENTITY_INSERT Make ON;

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 1, 'BMW', '10-04-2001', Id FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 2, 'Ford', '11-08-2011', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 3, 'Dodge', '06-12-2001', Id FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 4, 'Mercedes', '03-01-2013', Id FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 5, 'Subaru', '03-01-2013', Id FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 6, 'Honda', '03-01-2013', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 7, 'Toyota', '03-01-2013', Id FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'

INSERT INTO Make(MakeId, MakeName, DateAdded, UserId)
SELECT 8, 'Nissan', '03-01-2013', Id FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'


SET IDENTITY_INSERT Make OFF;

DBCC CHECKIDENT ('Model',RESEED, 1)

SET IDENTITY_INSERT Model ON;

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 1, 'X1', 1, '10-08-2002', Id FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 2, '5 Series', 1, '11-18-2012', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 3, 'Ranger', 2, '3-08-2018', Id FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 4, 'Expedition', 2, '12-09-2016', Id FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 5, 'Charger', 3, '07-08-2004', Id FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 6, 'Caravan', 3, '08-09-2008', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 7, 'Benz C-Class', 4, '11-12-2014', Id FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 8, 'Benz A-Class', 4, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 9, 'Forester', 5, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 10, 'Outback', 5, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 11, 'Ridgeline', 6, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 12, 'Odyssey', 6, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 13, 'Sienna', 7, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 14, 'Tundra', 7, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 15, 'Altima', 8, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'

INSERT INTO Model(ModelId, ModelName, MakeId, DateAdded, UserId)
SELECT 16, 'Pathfinder', 8, '02-09-2017', Id FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

SET IDENTITY_INSERT Model OFF;


DBCC CHECKIDENT ('Vehicle',RESEED, 1)

SET IDENTITY_INSERT Vehicle ON;

INSERT INTO Vehicle(VehicleId, VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, [Description], MakeId, ModelId, [Year], Sold, FeaturedVehicle, [Type], ImageFileName)
VALUES
(1, 'JTEBU11F470092662', 'White', 'Automatic', 0, 25000, 24500, 'Red', 'SUV', 'A Shiny Sedan with great comfort and ample leg room', 1, 1, 2000, 0, 0, 'New', 'inventory-1.jpg'),
(2, 'JT4RN56D0F0061406', 'Red', 'Manual', 5500, 5000, 4500, 'Black', 'Car', 'A Sporty Coupe for Adrenaline junkies', 1, 2, 2001, 0, 1, 'Used', 'inventory-2.jpg'),
(3, 'JKAEXMJ18ADA55383', 'Silver', 'Automatic', 0, 65000, 62500, 'Silver', 'Truck', 'Mighty Mouse crossover, small but effortlessly playful', 2, 3, 2002, 0, 1,'New', 'inventory-3.jpg'),
(4, '1HGCM56747A071243', 'Black', 'Manual', 10000, 15000, 14500, 'White', 'SUV', 'Poised and sophisticated; an executive sedan for the driver in charge', 2, 4, 2003, 0, 0, 'Used', 'inventory-4.jpg'),
(5, 'JTEBU11F470112662', 'Black', 'Automatic', 0, 25000, 24500, 'Silver', 'Car', 'A Shiny Sedan with great comfort and ample leg room', 3, 5, 2004, 0, 0, 'New', 'inventory-5.jpg'),
(6, 'JTEVC11F470112662', 'Black', 'Automatic', 0, 30000, 29000, 'Silver', 'Van', 'A Shiny Sedan with great comfort and ample leg room', 3, 6, 2005, 0, 0, 'New', 'inventory-6.jpg'),
(7, 'JT4R126D0F0061406', 'Red', 'Manual', 7500, 10000, 9500, 'Silver', 'Car', 'A Sporty Coupe for Adrenaline junkies', 4, 7, 2006, 0, 1, 'Used', 'inventory-7.jpg'),
(8, 'JT4RN5340F0061406', 'Red', 'Manual', 2500, 27000, 25500, 'Red', 'Car', 'A Sporty Coupe for Adrenaline junkies', 4, 8, 2007, 0, 1, 'Used', 'inventory-8.jpg'),
(9, 'PT4R124D0F0061406', 'White', 'Automatic', 50, 40000, 39500, 'Silver', 'SUV', 'A nice SUV', 5, 9, 2005, 0, 0, 'New', 'inventory-9.jpg'),
(10, 'KT4RN5340F0061406', 'Silver', 'Manual', 2500, 32000, 30500, 'Red', 'SUV', 'A Sporty Coupe for Adrenaline junkies', 5, 10, 2006, 0, 0, 'Used', 'inventory-10.jpg'),
(11, 'DT4R124D0F0061406', 'White', 'Automatic', 50, 70000, 67500, 'Silver', 'Truck', 'A nice SUV', 6, 11, 2007, 0, 0, 'New', 'inventory-11.jpg'),
(12, 'C24RN5340F0061406', 'Silver', 'Manual', 25000, 42000, 40500, 'Red', 'Van', 'A Sporty Coupe for Adrenaline junkies', 6, 12, 2008, 0, 0, 'Used', 'inventory-12.jpg'),
(13, 'JTEBU11F470092662', 'White', 'Automatic', 0, 125000, 124500, 'Red', 'Van', 'A Shiny Sedan with great comfort and ample leg room', 7, 13, 2009, 0, 0, 'New', 'inventory-13.jpg'),
(14, 'JT4RN56D0F0061406', 'Red', 'Manual', 5500, 50000, 49500, 'Black', 'Truck', 'A Sporty Coupe for Adrenaline junkies', 7, 14, 2010, 0, 1, 'Used', 'inventory-14.jpg'),
(15, 'JKAEXMJ18ADA55383', 'Silver', 'Automatic', 0, 95000, 92500, 'Silver', 'SUV', 'Mighty Mouse crossover, small but effortlessly playful', 8, 15, 2013, 0, 0,'New', 'inventory-15.jpg'),
(16, '1HGCM56747A071243', 'Black', 'Manual', 10000, 65000, 62500, 'White', 'Car', 'Poised and sophisticated; an executive sedan for the driver in charge', 8, 16, 2012, 0, 0, 'Used', 'inventory-16.jpg'),
(17, 'JTEBU11F470112662', 'Black', 'Automatic', 0, 75000, 74500, 'Silver', 'Car', 'A Shiny Sedan with great comfort and ample leg room', 1, 2, 2011, 0, 0, 'New', 'inventory-17.jpg'),
(18, 'JTEVC11F470112662', 'Black', 'Automatic', 0, 30000, 29000, 'Silver', 'SUV', 'A Shiny Sedan with great comfort and ample leg room', 2, 4, 2013, 0, 0, 'New', 'inventory-18.jpg'),
(19, 'JT4R126D0F0061406', 'Red', 'Manual', 7500, 10000, 9500, 'Silver', 'Van', 'A Sporty Coupe for Adrenaline junkies', 3, 6, 2012, 0, 0, 'Used', 'inventory-19.jpg'),
(20, 'JT4RN5340F0061406', 'Red', 'Manual', 2500, 27000, 25500, 'Red', 'Car', 'A Sporty Coupe for Adrenaline junkies', 4, 8, 2016, 0, 0, 'Used', 'inventory-20.jpg'),
(21, 'PT4R124D0F0061406', 'White', 'Automatic', 50, 55000, 54500, 'Silver', 'SUV', 'A nice SUV', 5, 10, 2015, 0, 0, 'New', 'inventory-21.jpg'),
(22, 'KT4RN5340F0061406', 'Silver', 'Manual', 2500, 2000, 1500, 'Red', 'Van', 'A Sporty Coupe for Adrenaline junkies', 6, 12, 2018, 0, 0, 'Used', 'inventory-22.jpg'),
(23, 'DT4R124D0F0061406', 'White', 'Automatic', 50, 10000, 9500, 'Silver', 'Truck', 'A nice SUV', 7, 14, 2019, 0, 0, 'New', 'inventory-23.jpg'),
(24, 'C24RN5340F0061406', 'Silver', 'Manual', 25000, 700, 550, 'Red', 'SUV', 'A Sporty Coupe for Adrenaline junkies', 8, 16, 2014, 0, 0, 'Used', 'inventory-24.jpg'),
(25, 'JTEBU11F470092662', 'White', 'Automatic', 0, 25000, 24500, 'Red', 'SUV', 'A Shiny Sedan with great comfort and ample leg room', 1, 1, 2000, 1, 0, 'New', 'inventory-1.jpg'),
(26, 'JT4RN56D0F0061406', 'Red', 'Manual', 5500, 5000, 4500, 'Black', 'Car', 'A Sporty Coupe for Adrenaline junkies', 1, 2, 2001, 1, 1, 'Used', 'inventory-2.jpg'),
(27, 'JKAEXMJ18ADA55383', 'Silver', 'Automatic', 0, 65000, 62500, 'Silver', 'Truck', 'Mighty Mouse crossover, small but effortlessly playful', 2, 3, 2002, 1, 1,'New', 'inventory-3.jpg'),
(28, '1HGCM56747A071243', 'Black', 'Manual', 10000, 15000, 14500, 'White', 'SUV', 'Poised and sophisticated; an executive sedan for the driver in charge', 2, 4, 2003, 1, 0, 'Used', 'inventory-4.jpg'),
(29, 'JTEBU11F470112662', 'Black', 'Automatic', 0, 25000, 24500, 'Silver', 'Car', 'A Shiny Sedan with great comfort and ample leg room', 3, 5, 2004, 1, 0, 'New', 'inventory-5.jpg'),
(30, 'JTEVC11F470112662', 'Black', 'Automatic', 0, 30000, 29000, 'Silver', 'Van', 'A Shiny Sedan with great comfort and ample leg room', 3, 6, 2005, 1, 0, 'New', 'inventory-6.jpg'),
(31, 'JT4R126D0F0061406', 'Red', 'Manual', 7500, 10000, 9500, 'Silver', 'Car', 'A Sporty Coupe for Adrenaline junkies', 4, 7, 2006, 1, 1, 'Used', 'inventory-7.jpg'),
(32, 'JT4RN5340F0061406', 'Red', 'Manual', 2500, 27000, 25500, 'Red', 'Car', 'A Sporty Coupe for Adrenaline junkies', 4, 8, 2007, 1, 1, 'Used', 'inventory-8.jpg'),
(33, 'PT4R124D0F0061406', 'White', 'Automatic', 50, 40000, 39500, 'Silver', 'SUV', 'A nice SUV', 5, 9, 2005, 1, 0, 'New', 'inventory-9.jpg'),
(34, 'KT4RN5340F0061406', 'Silver', 'Manual', 2500, 32000, 30500, 'Red', 'SUV', 'A Sporty Coupe for Adrenaline junkies', 5, 10, 2006, 1, 0, 'Used', 'inventory-10.jpg'),
(35, 'DT4R124D0F0061406', 'White', 'Automatic', 50, 70000, 67500, 'Silver', 'Truck', 'A nice SUV', 6, 11, 2007, 1, 0, 'New', 'inventory-11.jpg'),
(36, 'C24RN5340F0061406', 'Silver', 'Manual', 25000, 42000, 40500, 'Red', 'Van', 'A Sporty Coupe for Adrenaline junkies', 6, 12, 2008, 1, 0, 'Used', 'inventory-12.jpg'),
(37, 'JTEBU11F470092662', 'White', 'Automatic', 0, 125000, 124500, 'Red', 'Van', 'A Shiny Sedan with great comfort and ample leg room', 7, 13, 2009, 1, 0, 'New', 'inventory-13.jpg'),
(38, 'JT4RN56D0F0061406', 'Red', 'Manual', 5500, 50000, 49500, 'Black', 'Truck', 'A Sporty Coupe for Adrenaline junkies', 7, 14, 2010, 1, 1, 'Used', 'inventory-14.jpg'),
(39, 'JKAEXMJ18ADA55383', 'Silver', 'Automatic', 0, 95000, 92500, 'Silver', 'SUV', 'Mighty Mouse crossover, small but effortlessly playful', 8, 15, 2013, 1, 0,'New', 'inventory-15.jpg'),
(40, '1HGCM56747A071243', 'Black', 'Manual', 10000, 65000, 62500, 'White', 'Car', 'Poised and sophisticated; an executive sedan for the driver in charge', 8, 16, 2012, 1, 0, 'Used', 'inventory-16.jpg'),
(41, 'JTEBU11F470112662', 'Black', 'Automatic', 0, 75000, 74500, 'Silver', 'Car', 'A Shiny Sedan with great comfort and ample leg room', 1, 2, 2011, 1, 0, 'New', 'inventory-17.jpg'),
(42, 'JTEVC11F470112662', 'Black', 'Automatic', 0, 30000, 29000, 'Silver', 'SUV', 'A Shiny Sedan with great comfort and ample leg room', 2, 4, 2013, 1, 0, 'New', 'inventory-18.jpg'),
(43, 'JT4R126D0F0061406', 'Red', 'Manual', 7500, 10000, 9500, 'Silver', 'Van', 'A Sporty Coupe for Adrenaline junkies', 3, 6, 2012, 1, 0, 'Used', 'inventory-19.jpg'),
(44, 'JT4RN5340F0061406', 'Red', 'Manual', 2500, 27000, 25500, 'Red', 'Car', 'A Sporty Coupe for Adrenaline junkies', 4, 8, 2016, 1, 0, 'Used', 'inventory-20.jpg'),
(45, 'PT4R124D0F0061406', 'White', 'Automatic', 50, 55000, 54500, 'Silver', 'SUV', 'A nice SUV', 5, 10, 2015, 1, 0, 'New', 'inventory-21.jpg'),
(46, 'KT4RN5340F0061406', 'Silver', 'Manual', 2500, 2000, 1500, 'Red', 'Van', 'A Sporty Coupe for Adrenaline junkies', 6, 12, 2018, 1, 0, 'Used', 'inventory-22.jpg'),
(47, 'DT4R124D0F0061406', 'White', 'Automatic', 50, 10000, 9500, 'Silver', 'Truck', 'A nice SUV', 7, 14, 2019, 1, 0, 'New', 'inventory-23.jpg'),
(48, 'C24RN5340F0061406', 'Silver', 'Manual', 25000, 700, 550, 'Red', 'SUV', 'A Sporty Coupe for Adrenaline junkies', 8, 16, 2014, 1, 0, 'Used', 'inventory-24.jpg')


SET IDENTITY_INSERT Vehicle OFF;


DBCC CHECKIDENT ('Special',RESEED, 1)

SET IDENTITY_INSERT Special ON;

INSERT INTO Special(SpecialId, Title, [Description])
VALUES
(1, 'College Graduate Program', 'Through the Auto Finance program, we are pleased to offer auto financing for college graduates to purchase a used vehicle.'),
(2, 'First Time Car Buyer', 'Are you ready to purchase your first vehicle and preparing to apply for auto financing? We are here to help!'),
(3, 'Low Credit Special', 'Even if you don’t have perfect credit, or this is your first time financing a vehicle, we may have financing options to fit your needs.')

SET IDENTITY_INSERT Special OFF;


DBCC CHECKIDENT ('SaleLog',RESEED, 1)

SET IDENTITY_INSERT SaleLog ON;

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 1, 'Aniket', 'aniket@gmail.com','112 Awesome st', 'Chicago', 'MI', '97787', 19000, 'Dealer Finance', 25, 2223334444, Id, '2002-06-23 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 2, 'Arjun', 'mahabharat@gmail.com','112 kuru st', 'New York', 'NY', '32787', 25000, 'Bank Finance', 26, 2223224444, Id, '2018-08-13 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 3, 'Jay', 'jay@gmail.com','22 some st', 'Newark', 'CA', '11787', 29000, 'Cash', 27, 2223224444, Id, '2012-11-02 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 4, 'Arun', 'arun@gmail.com','11 some st', 'Newark', 'CA', '11787', 5000, 'Cash', 28, 1123224444, Id, '2007-05-03 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 5, 'Imran', 'imran@gmail.com','112 Awesome st', 'Chicago', 'MI', '97787', 65000, 'Dealer Finance', 29, 2223334444, Id, '2001-06-23 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 6, 'Julie', 'julie@gmail.com','112 kuru st', 'New York', 'NY', '32787', 5000, 'Bank Finance', 30, 2223224444, Id, '2019-05-13 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 7, 'Danny', 'danny@gmail.com','22 some st', 'Newark', 'CA', '11787', 9000, 'Cash', 31, 2223224444, Id, '2003-10-02 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 8, 'Ayesha', 'ayesha@gmail.com','11 some st', 'Newark', 'CA', '11787', 55000, 'Bank Finance', 32, 1123224444, Id, '2007-05-30 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 9, 'Aniket', 'aniket@gmail.com','112 Awesome st', 'Chicago', 'MI', '97787', 19000, 'Dealer Finance', 33, 2223334444, Id, '2012-06-23 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 10, 'Arjun', 'mahabharat@gmail.com','112 kuru st', 'New York', 'NY', '32787', 25000, 'Bank Finance', 34, 2223224444, Id, '2005-08-13 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 11, 'Jay', 'jay@gmail.com','22 some st', 'Newark', 'CA', '11787', 29000, 'Cash', 35, 2223224444, Id, '2012-11-02 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 12, 'Arun', 'arun@gmail.com','11 some st', 'Newark', 'CA', '11787', 5000, 'Cash', 36, 1123224444, Id, '2015-05-30 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 13, 'Imran', 'imran@gmail.com','112 Awesome st', 'Chicago', 'MI', '97787', 65000, 'Dealer Finance', 37, 2223334444, Id, '2004-06-23 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 14, 'Julie', 'julie@gmail.com','112 kuru st', 'New York', 'NY', '32787', 5000, 'Bank Finance', 38, 2223224444, Id, '2014-08-13 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 15, 'Danny', 'danny@gmail.com','22 some st', 'Newark', 'CA', '11787', 9000, 'Cash', 39, 2223224444, Id, '2001-11-02 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 16, 'Ayesha', 'ayesha@gmail.com','11 some st', 'Newark', 'CA', '11787', 55000, 'Bank Finance', 40, 1123224444, Id, '2010-05-06 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 17, 'Aniket', 'aniket@gmail.com','112 Awesome st', 'Chicago', 'MI', '97787', 19000, 'Dealer Finance', 41, 2223334444, Id, '2002-06-23 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 18, 'Arjun', 'mahabharat@gmail.com','112 kuru st', 'New York', 'NY', '32787', 25000, 'Bank Finance', 42, 2223224444, Id, '2018-08-13 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales1@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 19, 'Jay', 'jay@gmail.com','22 some st', 'Newark', 'CA', '11787', 29000, 'Cash', 43, 2223224444, Id, '2012-11-02 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 20, 'Arun', 'arun@gmail.com','11 some st', 'Newark', 'CA', '11787', 5000, 'Cash', 44, 1123224444, Id, '2007-05-03 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales2@xxx.net'

INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 21, 'Imran', 'imran@gmail.com','112 Awesome st', 'Chicago', 'MI', '97787', 65000, 'Dealer Finance', 45, 2223334444, Id, '2001-06-23 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 22, 'Julie', 'julie@gmail.com','112 kuru st', 'New York', 'NY', '32787', 5000, 'Bank Finance', 46, 2223224444, Id, '2019-05-13 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales3@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 23, 'Danny', 'danny@gmail.com','22 some st', 'Newark', 'CA', '11787', 9000, 'Cash', 47, 2223224444, Id, '2003-10-02 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'


INSERT INTO SaleLog(SaleId, BuyerName, Email, Street1, City, [State], ZipCode, PurchasePrice, PurchaseType, VehicleId, Phone, SalesUserId, PurchaseDate)
SELECT 24, 'Ayesha', 'ayesha@gmail.com','11 some st', 'Newark', 'CA', '11787', 55000, 'Bank Finance', 48, 1123224444, Id, '2007-05-30 07:30:20' FROM AspNetUsers WHERE UserName = 'Sales4@xxx.net'

SET IDENTITY_INSERT SaleLog OFF;

END
GO