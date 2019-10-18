CREATE PROC InsertIntoOrderProducts
@OrderID int,
@ProductID int,
@Quantity int,
@Price real
AS
BEGIN
	INSERT INTO OrderProducts(OrderID,ProductID, Quantity,Price)
	VALUES(@OrderID,@ProductID, @Quantity, @Price)
END;