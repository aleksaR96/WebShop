CREATE PROC InsertFeaturedProperty
@CategoryID int,
@PropertyID int
AS
BEGIN
	INSERT INTO FeaturedProperties
	(
		CategoryID,
		PropertyID
	)
	VALUES
	(
		@CategoryID,
		@PropertyID
	)
END;