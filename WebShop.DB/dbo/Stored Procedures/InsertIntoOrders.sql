CREATE PROC InsertIntoOrders
@UserID int,
@TotalQuantity int,
@TotalPrice real
AS
BEGIN
	INSERT INTO Orders(UserID, TotalQuantity, TotalPrice)
	VALUES(@UserID, @TotalQuantity , @TotalPrice)
END;