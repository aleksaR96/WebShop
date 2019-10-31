CREATE PROC DeletePropertyValue
@ID int
AS
BEGIN
	DELETE FROM PropertyValues
	WHERE ID = @ID
END;