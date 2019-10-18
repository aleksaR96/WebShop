CREATE PROC DeleteProductsByID
@ID int
AS
BEGIN
	DELETE FROM Products
	WHERE ProductID = @ID
END;