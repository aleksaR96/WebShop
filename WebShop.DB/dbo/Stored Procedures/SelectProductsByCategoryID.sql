CREATE PROC SelectProductsByCategoryID
@ID int
AS
BEGIN
	SELECT *
	FROM Products
	WHERE CategoryID = @ID
END;