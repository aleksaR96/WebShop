CREATE PROC UpdatePropertyList
@ID int,
@Name nvarchar(30),
@GroupID int
AS
BEGIN
	UPDATE PropertyList
	SET
		Name = @Name,
		GroupID = @GroupID
	WHERE ID = @ID
END;