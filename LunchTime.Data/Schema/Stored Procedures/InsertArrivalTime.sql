CREATE PROCEDURE [dbo].[InsertArrivalTime]
	@ArrivalTime DATETIME,
	@Name VARCHAR(50)
AS
	IF EXISTS
	(
		SELECT
			[RestaurantId]
		FROM
			[Restaurants]
		WHERE
			[Name] = @Name
	)
	INSERT INTO
		[ArrivalTimes]
		(
			[ArrivalTime],
			[RestaurantId]
		)
	VALUES
		(
			@ArrivalTime,
			(
				SELECT
					[RestaurantId]
				FROM
					[Restaurants]
				WHERE
					[Name] = @Name
			)
		)