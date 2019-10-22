CREATE PROC DeletePropertyGroup
@ID int
AS
BEGIN
	DELETE FROM PropertyGroups
	WHERE ID = @ID
END;