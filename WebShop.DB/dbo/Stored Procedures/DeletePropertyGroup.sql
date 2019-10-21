CREATE PROC DeletePropertyGroup
@ID int
AS
BEGIN
	DELETE FROM PropertyGroup
	WHERE ID = @ID
END;