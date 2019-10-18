CREATE PROC CountProductsByCategoryID
@ID int
AS
BEGIN
	SELECT COUNT(*)
	FROM Products
	WHERE CategoryID = @ID
END;