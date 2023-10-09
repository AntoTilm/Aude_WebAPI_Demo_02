DELETE FROM [MM_Recipe_Ingredient];
DELETE FROM [Recipe];
DELETE FROM [Category];
DELETE FROM [Ingredient];

SET IDENTITY_INSERT [Category] ON; /* Désactive l'identity -> pour pouvoir mettre vos propres id*/
INSERT INTO [Category] ([Id], [Name])
	VALUES (1, 'Dessert'),
			(2, 'Plat'),
			(3, 'Entrée'),
			(4, 'Apéro');
SET IDENTITY_INSERT [Category] OFF;

SET IDENTITY_INSERT [Ingredient] ON;
INSERT INTO [Ingredient] ([Id], [Name], [IsVegetarian], [IsVegan])
	VALUES (1, 'Farine', 1, 1),
			(2, 'Lait', 1, 0),
			(3, 'Sucre', 1, 1),
			(4, 'Oeuf', 1, 0),
			(5, 'Sel', 1, 1),
			(6, 'Beurre', 1, 0);
SET IDENTITY_INSERT [Ingredient] OFF;

SET IDENTITY_INSERT [Recipe] ON;
INSERT INTO [Recipe] ([Id], [Name], [Origin], [CategoryId], [Instructions])
	VALUES (1, 'Les crêpes d''Aude', 'La Rochelle', 1, 'Mettez la farine dans un saladier avec le sel et le sucre. 
	Faites un puits au milieu et versez-y les oeufs.
	Commencez à mélanger doucement. Quand le mélange devient épais, ajoutez le lait froid petit à petit.
	Quand tout le lait est mélangé, la pâte doit être assez fluide. Si elle vous paraît trop épaisse, rajoutez un peu de lait. Ajoutez ensuite le beurre fondu refroidi, mélangez bien.
	Faites cuire les crêpes dans une poêle chaude (par précaution légèrement huilée si votre poêle à crêpes n''est pas anti-adhésive). Versez une petite louche de pâte dans la poêle, faites un mouvement de rotation pour répartir la pâte sur toute la surface. Posez sur le feu et quand le tour de la crêpe se colore en roux clair, il est temps de la retourner.
Laissez cuire environ une minute de ce côté et la crêpe est prête.)')
SET IDENTITY_INSERT [Recipe] OFF;

INSERT INTO [MM_Recipe_Ingredient]([RecipeId], [IngredientId], [Quantity], [Unit])
VALUES (1, 1, 250, 'g'),
		(1, 2, 0.5, 'L'),
		(1, 3, 2, 'c.à.s'),
		(1, 4, 4, 'pièces'),
		(1, 5, 1, 'pincée'),
		(1, 6, 50, 'g')