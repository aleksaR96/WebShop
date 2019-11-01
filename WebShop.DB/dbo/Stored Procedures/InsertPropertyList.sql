CREATE PROC InsertPropertyList
@Name nvarchar(30),
@GroupID int,
@RelatedPropertyID int
AS
BEGIN
	INSERT INTO PropertyList
	(Name, GroupID, RelatedPropertyID)
	VALUES
		(
			@Name,
			@GroupID,
			@RelatedPropertyID
		);
	SELECT *
	FROM PropertyList
	WHERE
		Name = @Name
		AND
		GroupID = @GroupID;
END;