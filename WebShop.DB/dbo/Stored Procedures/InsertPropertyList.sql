CREATE PROC InsertPropertyList
@Name nvarchar(30),
@GroupID int
AS
BEGIN
	INSERT INTO PropertyList
	(Name, GroupID)
	VALUES
		(
			@Name,
			@GroupID
		);
	SELECT *
	FROM PropertyList
	WHERE
		Name = @Name
		AND
		GroupID = @GroupID;
END;