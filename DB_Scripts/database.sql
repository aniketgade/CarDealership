USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE NAME='GuildCars_Aniket')
		DROP DATABASE GuildCars_Aniket
GO

CREATE DATABASE GuildCars_Aniket
GO