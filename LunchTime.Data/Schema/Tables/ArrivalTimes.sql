CREATE TABLE [dbo].[ArrivalTimes] (
    [ArrivalTimesId] INT      IDENTITY (1, 1) NOT NULL,
    [RestaurantId]   INT      NOT NULL,
    [ArrivalTime]    DATETIME NOT NULL,
    [Date]           AS       (CONVERT([date],[ArrivalTime],0)),
    [Time]           AS       (CONVERT([time](3),[ArrivalTime],0)),
    PRIMARY KEY CLUSTERED ([ArrivalTimesId] ASC),
    CONSTRAINT [FK_ArrivalTimes_Restaurants] FOREIGN KEY ([RestaurantId]) REFERENCES [dbo].[Restaurants] ([RestaurantId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [UK_Date_RestaurantId] UNIQUE NONCLUSTERED ([Date] ASC, [RestaurantId] ASC)
);


