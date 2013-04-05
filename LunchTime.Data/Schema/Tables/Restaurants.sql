CREATE TABLE [dbo].[Restaurants]
(
	[RestaurantId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL, 
	CONSTRAINT [Restaurants_Name_UK] UNIQUE ([Name])
)
