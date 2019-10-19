CREATE PROC SelectPropertyGroup
@ID int
AS
BEGIN
	SELECT *
	FROM PropertyGroups
	WHERE ID = @ID
END;