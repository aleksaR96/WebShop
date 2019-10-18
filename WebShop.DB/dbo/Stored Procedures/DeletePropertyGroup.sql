CREATE PROC DeletePropertyGroup
@ID int
AS
BEGIN
	DELETE FROM PropertyGroup
	WHERE GroupID = @ID
END;