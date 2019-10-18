CREATE PROC SelectOrderProductsByID
@ID int
AS
BEGIN
	Select *
	FROM OrderProducts
	WHERE OrderProductsID = @ID
END;