CREATE PROCEDURE
	[dbo].[SanitizeNames]
	(
		@Good int,
		@Bad int
	)
AS
	UPDATE
		[ArrivalTimes]
	SET
		[RestaurantId] = @Good
	WHERE
		[RestaurantId] = @Bad

	DELETE
	FROM
		[Restaurants]
	WHERE
		[RestaurantId] = @Bad