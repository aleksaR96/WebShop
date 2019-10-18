CREATE PROC SelectFeaturedPropertiesByCategoryID
@CategoryID int
AS
BEGIN
	SELECT *
	FROM FeaturedProperties
	WHERE CategoryID = @CategoryID
END;