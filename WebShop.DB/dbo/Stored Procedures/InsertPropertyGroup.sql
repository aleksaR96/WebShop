CREATE PROC InsertPropertyGroup
@Name nvarchar(30)
AS
BEGIN
	INSERT INTO PropertyGroups
	(
		Name
	)
	VALUES
	(
		@Name
	)
END;