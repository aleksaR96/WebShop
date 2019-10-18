CREATE PROC SelectFeaturedPropertyByID
@ID int
AS
BEGIN
	SELECT *
	FROM FeaturedProperties
	WHERE ID = @ID
END;