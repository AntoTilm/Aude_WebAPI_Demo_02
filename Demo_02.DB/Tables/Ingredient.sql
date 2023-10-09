CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[IsVegetarian] BIT DEFAULT 0,
	[IsVegan] BIT DEFAULT 0,
	CONSTRAINT PK_Ingredient PRIMARY KEY ([Id]),
	CONSTRAINT UK_Ingredient__Name UNIQUE ([Name])
)
