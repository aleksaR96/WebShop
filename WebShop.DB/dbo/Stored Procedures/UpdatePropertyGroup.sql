CREATE PROC UpdatePropertyGroup
@ID int,
@Name nvarchar(30)
AS
BEGIN
	UPDATE PropertyGroups
	SET Name = @Name
	WHERE ID = @ID
END;