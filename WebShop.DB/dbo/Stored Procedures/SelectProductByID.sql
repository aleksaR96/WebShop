CREATE PROC SelectProductByID
@ID int
AS
BEGIN
	Select *
	FROM Products
	WHERE ProductID = @ID
END;