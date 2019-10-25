CREATE PROC UpdatePropertyGroup
@ID int,
@Name nvarchar(30),
@Alias nvarchar(30),
@SupGroup int
AS
BEGIN
	UPDATE PropertyGroups
	SET
		Name = @Name,
		Alias = @Alias,
		SupGroup = @SupGroup
	WHERE ID = @ID
END;