CREATE PROC UpdateFeaturedProperty
@ID int,
@CategoryID int,
@PropertyID int
AS
BEGIN
	UPDATE FeaturedProperties
	SET
		CategoryID = @CategoryID,
		PropertyID = @PropertyID
	WHERE
		ID = @ID
END;