CREATE TABLE [dbo].[ArrivalTimes]
(
	[ArrivalTimesId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[RestaurantId] INT NOT NULL, 
	[ArrivalTime] DATETIME NOT NULL, 
    [Date] AS CONVERT(DATE, [ArrivalTime]), 
    [Time] AS CONVERT(TIME, [ArrivalTime]),
    CONSTRAINT [FK_ArrivalTimes_Restaurants] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants]([RestaurantId]) ON DELETE CASCADE ON UPDATE CASCADE
)
