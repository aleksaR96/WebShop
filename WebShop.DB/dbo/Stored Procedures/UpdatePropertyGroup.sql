CREATE PROC UpdatePropertyGroup
@ID int,
@Name nvarchar(30),
@Alias nvarchar(30),
@CategoryID int,
@SupGroup int
AS
BEGIN
	UPDATE PropertyGroups
	SET
		Name = @Name,
		Alias = @Alias,
		SupGroup = @SupGroup,
		CategoryID = @CategoryID
	WHERE ID = @ID;

	SELECT *
	FROM PropertyGroups
	WHERE ID = @ID;
END;