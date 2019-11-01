CREATE PROC UpdatePropertyList
@ID int,
@Name nvarchar(30),
@GroupID int,
@RelatedPropertyID int
AS
BEGIN
	UPDATE PropertyList
	SET
		Name = @Name,
		GroupID = @GroupID,
		RelatedPropertyID = @RelatedPropertyID
	WHERE ID = @ID;

	SELECT *
	FROM PropertyList
	WHERE ID = @ID;
END;