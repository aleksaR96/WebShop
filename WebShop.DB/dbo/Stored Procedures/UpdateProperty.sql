CREATE PROC UpdateProperty
@ID int,
@ProductID int,
@PropertyID int,
@Value nvarchar(30)
AS
BEGIN
	UPDATE Properties
	SET
		ProductID = @ProductID,
		PropertyID = @PropertyID,
		Value = @Value
	WHERE ID = @ID
END;