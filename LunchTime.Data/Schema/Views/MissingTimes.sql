CREATE VIEW
    [dbo].[MissingTimes]
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
        AND at.[Date] NOT IN -- Known dates with missing emails
        (
            '2012-10-10',
            '2012-10-25',
            '2012-11-05',
            '2012-12-05'
        )
    GROUP BY
        at.[Date],
        r.[Name]
