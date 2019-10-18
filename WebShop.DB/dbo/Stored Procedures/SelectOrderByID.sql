CREATE PROC SelectOrderByID
@ID int
AS
BEGIN
	Select *
	FROM Orders
	WHERE OrderID = @ID
END;