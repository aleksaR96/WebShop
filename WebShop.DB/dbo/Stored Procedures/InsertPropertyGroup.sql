CREATE PROC InsertPropertyGroup
@Name nvarchar(30),
@Alias nvarchar(30),
@CategoryID int,
@SupGroup int
AS
BEGIN
	INSERT INTO PropertyGroups
	(
		Name,
		Alias,
		SupGroup,
		CategoryID
	)
	VALUES
	(
		@Name,
		@Alias,
		@SupGroup,
		@CategoryID
	);

	SELECT *
	FROM PropertyGroups
	WHERE Name = @Name
		AND Alias = @Alias
		AND SupGroup = @SupGroup
		AND CategoryID = @CategoryID;
END;