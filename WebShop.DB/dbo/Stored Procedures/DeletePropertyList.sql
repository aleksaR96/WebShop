CREATE PROC DeletePropertyList
@ID int
AS
BEGIN
	DELETE FROM PropertyList
	WHERE ID = @ID
END;