CREATE PROC DeleteCategoryByID
@ID int
AS
BEGIN
	DELETE FROM Category
	WHERE CategoryID = @ID
END;