CREATE PROC UpdatePropertyByProductIDAndPropertyID
@ProductID int,
@PropertyID int,
@Value nvarchar(30)
AS
BEGIN
	UPDATE Properties
	SET
		Value = @Value
	WHERE
		ProductID = @ProductID
		AND PropertyID = @PropertyID
END;