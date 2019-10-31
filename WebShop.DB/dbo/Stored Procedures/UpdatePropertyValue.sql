CREATE PROC UpdatePropertyValue
@ID int,
@PropertyID int,
@Value nvarchar(30)
AS
BEGIN
	UPDATE PropertyValues
	SET
		PropertyID = @PropertyID,
		Value = @Value
	WHERE
		ID = @ID
END;