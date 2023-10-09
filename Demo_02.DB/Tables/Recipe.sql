CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Origin] NVARCHAR(100),
	[CategoryId] INT NOT NULL,
	[Instructions] NVARCHAR(max),
	CONSTRAINT PK_Recipe PRIMARY KEY ([Id]),
	CONSTRAINT FK_Recipe_Category FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]) 
)
