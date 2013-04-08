CREATE VIEW
    [dbo].[PotentialMissingTimes]
AS
    SELECT
        at.[Date],
        r.[Name]
    FROM
        [ArrivalTimes] at
    JOIN
        [Restaurants] r
    ON
        at.[RestaurantId] = r.[RestaurantId]
    WHERE
        at.[Date] IN
        (
            SELECT
                [Date]
            FROM
                [ArrivalTimes]
            GROUP BY
                [Date]
            HAVING
                COUNT([Date]) <> 3
        )
        AND at.[Date] NOT IN
        (
            SELECT
                DISTINCT([Date])
            FROM
                [KnownMissingTimes]
        )
    GROUP BY
        at.[Date],
        r.[Name]
