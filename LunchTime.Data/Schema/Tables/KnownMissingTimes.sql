CREATE TABLE [dbo].[KnownMissingTimes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RestaurantId] INT NOT NULL, 
    [Date] DATE NOT NULL, 
    CONSTRAINT [FK_KnownMissingTimes_Restaurants] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants]([RestaurantId]), 
    CONSTRAINT [UK_Restaurant_Date] UNIQUE ([RestaurantId], [Date])
)
