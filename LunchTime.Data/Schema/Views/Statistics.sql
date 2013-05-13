CREATE VIEW
	[dbo].[Statistics]
AS
 
	WITH
		[Medians]
	AS
	(
		SELECT
			DISTINCT([RestaurantID]),
			[Median] =
			((
				SELECT
					MAX([TimeFloat])
				FROM
				(
					SELECT TOP 50 PERCENT
						[TimeFloat] = CAST(CAST([Time] AS DATETIME) AS FLOAT)
					FROM
						[ArrivalTimes]
					WHERE
						[RestaurantId] = at.[RestaurantId]
					ORDER BY
						[Time]
				) BottomHalf
			)
				+
			(
				SELECT
					MIN([TimeFloat])
				FROM
				(
					SELECT TOP 50 PERCENT
						[TimeFloat] = CAST(CAST([Time] AS DATETIME) AS FLOAT)
					FROM
						[ArrivalTimes]
					WHERE
						[RestaurantId] = at.[RestaurantId]
					ORDER BY
						[Time] DESC
				) TopHalf
			)) / 2
		FROM
			[ArrivalTimes] at
	),
		[BasicStats]
	AS
	(
		SELECT
			r.[Name],
			[Count] = COUNT(at.[ArrivalTime]),
			[Min] = MIN(at.[Time]),
			[Max] = MAX(at.[Time]),
			[MeanFloat] = AVG(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)),
			[Mean] = CAST(CAST(AVG(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)) AS DATETIME) AS TIME(3)),
			[Median] = CAST(CAST(med.[Median] AS DATETIME) AS TIME(3)),
			[StdevFloat] = STDEV(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)),
			[Standard Deviation] = CAST(CAST(STDEV(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)) AS DATETIME) AS TIME(3))
		FROM
			[ArrivalTimes] at
		JOIN
			[Restaurants] r
		ON
			at.[RestaurantId] = r.[RestaurantId]
		JOIN
			[Medians] med
		ON
			at.[RestaurantId] = med.[RestaurantId]
		GROUP BY
			r.[RestaurantId],
			r.[Name],
			med.[Median]
	)

	SELECT
		[Name],
		[Count],
		[Min],
		[Max],
		[Range] = DATEDIFF(MINUTE, [Min], [Max]),
		[Mean],
		[Median],
		[Standard Deviation],
		[95% Confidence Interval] = CONVERT(VARCHAR(12), CAST(CAST([MeanFloat] - 1.96 * [StdevFloat] AS DATETIME) AS TIME)) + ' - ' + CONVERT(VARCHAR(12), CAST(CAST([MeanFloat] + 1.96 * [StdevFloat] AS DATETIME) AS TIME))
	FROM
		[BasicStats]
