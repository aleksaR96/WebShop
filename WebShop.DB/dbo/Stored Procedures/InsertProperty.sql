CREATE PROC InsertProperty
@ProductID int,
@PropertyID int,
@Value nvarchar(30)
AS
BEGIN
	INSERT INTO Properties
	(
		ProductID,
		PropertyID,
		Value
	)
	VALUES
	(
		@ProductID,
		@PropertyID,
		@Value
	)
END;