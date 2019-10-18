CREATE PROC SelectFeaturedPropertyByCategoryIDAndPropertyID
@CategoryID int,
@PropertyID int
AS
BEGIN
	SELECT *
	FROM FeaturedProperties
	WHERE CategoryID = @CategoryID
	AND PropertyID = @PropertyID
END;