CREATE PROC InsertPropertyGroup
@Name nvarchar(30),
@Alias nvarchar(30),
@SupGroup int
AS
BEGIN
	INSERT INTO PropertyGroups
	(
		Name,
		Alias,
		SupGroup
	)
	VALUES
	(
		@Name,
		@Alias,
		@SupGroup
	)
END;