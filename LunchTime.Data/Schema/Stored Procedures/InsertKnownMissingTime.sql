CREATE PROCEDURE
	[dbo].[InsertKnownMissingTime]
	(
		@Restaurant VARCHAR(50),
		@Date DATE
	)
AS
	IF NOT EXISTS
	(
		SELECT
			*
		FROM
			[KnownMissingTimes] mt
		JOIN
			[Restaurants] r
		ON
			r.[RestaurantId] = mt.[RestaurantId]
		WHERE
			r.[Name] = @Restaurant
			AND mt.[Date] = @Date
	)
	AND EXISTS
	(
		SELECT
			[Name]
		FROM
			[Restaurants]
		WHERE
			[Name] = @Restaurant
	)
	INSERT INTO
		[KnownMissingTimes]
		(
			[Date],
			[RestaurantId]
		)
	VALUES
		(
			@Date,
			(
				SELECT
					[RestaurantId]
				FROM
					[Restaurants]
				WHERE
					[Name] = @Restaurant
			)
		)