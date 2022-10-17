CREATE DATABASE [DiplomskiDb];
GO

USE [DiplomskiDb];
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Stores')
  BEGIN
    EXEC ('CREATE SCHEMA Stores;');
  END
