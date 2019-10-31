CREATE PROC InsertPropertyValue
@PropertyID int,
@Value nvarchar(30)
AS
BEGIN
	INSERT INTO PropertyValues (PropertyID, Value)
	VALUES
	(
		@PropertyID,
		@Value
	)
END;