CREATE TABLE [dbo].[MM_Recipe_Ingredient]
(
	[RecipeId] INT NOT NULL,
	[IngredientId] INT NOT NULL,
	[Quantity] DECIMAL(5,2) NOT NULL,
	[Unit] NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Recipe_Ingredient PRIMARY KEY ([RecipeId], [IngredientId]),
	CONSTRAINT FK_MM_Recipe FOREIGN KEY ([RecipeId]) REFERENCES [Recipe]([Id]),
	CONSTRAINT FK_MM_Ingredient FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient]([Id])
)
