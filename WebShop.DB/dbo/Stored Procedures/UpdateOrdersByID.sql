CREATE PROC UpdateOrdersByID
@ID int,
@UserID int,
@TotalQuantity int,
@TotalPrice real

AS
BEGIN
	
	UPDATE Orders
	SET UserID = @UserID,  TotalQuantity= @TotalQuantity,TotalPrice=@TotalPrice
	WHERE OrderID = @ID
END;