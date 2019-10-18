CREATE PROC SelectCategoryByID
@ID int
AS
BEGIN
	Select *
	FROM Category
	WHERE CategoryID = @ID
END;