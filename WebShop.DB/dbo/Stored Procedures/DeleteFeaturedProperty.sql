CREATE PROC DeleteFeaturedProperty
@ID int
AS
BEGIN
	DELETE FROM FeaturedProperties
	WHERE ID = @ID
END;