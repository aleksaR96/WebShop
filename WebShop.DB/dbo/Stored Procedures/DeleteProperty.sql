CREATE PROC DeleteProperty
@ID int
AS
BEGIN
	DELETE FROM Properties
	WHERE ID = @ID
END;