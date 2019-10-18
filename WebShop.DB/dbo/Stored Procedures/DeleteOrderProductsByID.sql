CREATE PROC DeleteOrderProductsByID
@ID int
AS
BEGIN
	DELETE FROM OrderProducts
	WHERE OrderProductsID = @ID
END;