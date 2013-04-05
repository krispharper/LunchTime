CREATE VIEW
    [dbo].[Statistics]
AS
    SELECT
        r.[RestaurantId],
        r.Name,
        [Count] = COUNT(at.[ArrivalTime]),
        [Average] = CAST(CAST(AVG(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)) AS DATETIME) AS TIME(3)),
        [Min] = MIN(at.[Time]),
        [Max] = MAX(at.[Time])
    FROM
        [ArrivalTimes] at
    JOIN
        [Restaurants] r
    ON
        at.[RestaurantId] = r.[RestaurantId]
    GROUP BY
        r.[RestaurantId],
        r.[Name]
