/* Drop Foreign Key Constraints */
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all";
GO

while(exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE='FOREIGN KEY'))
begin
declare @sql nvarchar(2000)
SELECT TOP 1 @sql=('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
+ '] DROP CONSTRAINT [' + CONSTRAINT_NAME + ']')
FROM information_schema.table_constraints
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'
exec (@sql)
end

/* Drop Tables */
EXEC sp_msforeachtable "DROP TABLE ?";
GO

EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all";
GO

/* Create Tables */
/* Stores */
CREATE TABLE [Stores].[Store] (
  [Id] uniqueidentifier PRIMARY KEY DEFAULT (NEWID()),
  [Name] varchar(3) NOT NULL
)
GO

CREATE TABLE [Stores].[Article] (
  [Id] uniqueidentifier PRIMARY KEY DEFAULT (NEWID()),
  [CodeDob] varchar(25) NOT NULL,
  [Code] varchar(250) NOT NULL,
  [Name] varchar(250) NOT NULL,
  [Entry] decimal(20,10) NOT NULL,
  [Exit] decimal(20,10) NOT NULL,
  [SingularPrice] decimal(20,10) NOT NULL,
  [Owe] decimal(20,10) NOT NULL,
  [Demand] decimal(20,10) NOT NULL,
  [Tariff] decimal(20,10) NOT NULL,
  [PLA] varchar(100) NOT NULL,
  [OP] decimal(20,10) NOT NULL,
  [Rebate] decimal(20,10) NOT NULL,
  [BuyPrice] decimal(20,10) NOT NULL,
  [Tax] decimal(20,10) NOT NULL,
  [Week] date NOT NULL,
  [StoreId] uniqueidentifier NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */
/* Stores */
CREATE INDEX [IXFK_Article_StoreId] ON [Stores].[Article] ("StoreId")
GO

/* Create Foreign Key Constraints */
/* Stores */
ALTER TABLE [Stores].[Article] ADD CONSTRAINT [IX_Article_ArticleId] FOREIGN KEY ([StoreId]) REFERENCES [Stores].[Store] ([Id]) ON DELETE CASCADE
GO
