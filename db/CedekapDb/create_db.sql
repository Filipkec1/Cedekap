CREATE DATABASE [CedekapDb];
GO

USE [CedekapDb];
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Stores')
  BEGIN
    EXEC ('CREATE SCHEMA Stores;');
  END

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'User')
  BEGIN
    EXEC ('CREATE SCHEMA User;');
  END
