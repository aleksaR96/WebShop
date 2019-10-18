CREATE PROC UpdateOrderProductsByID
@ID int,
@OrderID int,
@ProductID int,
@Quantity int,
@Price real

AS
BEGIN
	
	UPDATE OrderProducts
	SET OrderID = @OrderID, ProductID=@ProductID, Quantity=@Quantity, Price=@Price
	WHERE OrderProductsID = @ID
END;