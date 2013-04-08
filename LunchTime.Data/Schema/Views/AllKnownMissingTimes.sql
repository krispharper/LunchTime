CREATE VIEW
    [dbo].[AllKnownMissingTimes]
AS
    SELECT
        mt.[Date],
        r.[Name]
    FROM
        [KnownMissingTimes] mt
    JOIN
        [Restaurants] r
    ON
        mt.[RestaurantId] = r.[RestaurantId]