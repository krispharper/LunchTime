CREATE VIEW
	[dbo].[Statistics]
AS
	WITH
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
			[StdevFloat] = STDEV(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)),
			[Standard Deviation] = CAST(CAST(STDEV(CAST(CAST(at.[Time] AS DATETIME) AS FLOAT)) AS DATETIME) AS TIME(3))
		FROM
			[ArrivalTimes] at
		JOIN
			[Restaurants] r
		ON
			at.[RestaurantId] = r.[RestaurantId]
		GROUP BY
			r.[RestaurantId],
			r.[Name]
	)

	SELECT
		[Name],
		[Count],
		[Min],
		[Max],
		[Range] = DATEDIFF(MINUTE, [Min], [Max]),
		[Mean],
		[Standard Deviation],
		[95% Confidence Interval] = CONVERT(VARCHAR(12), CAST(CAST([MeanFloat] - 1.96 * [StdevFloat] AS DATETIME) AS TIME)) + ' - ' + CONVERT(VARCHAR(12), CAST(CAST([MeanFloat] + 1.96 * [StdevFloat] AS DATETIME) AS TIME))
	FROM
		[BasicStats]
