CREATE PROC SelectPropertyListByPropertyGroup
@GroupID int
AS
BEGIN
	SELECT *
	FROM PropertyList
	WHERE GroupID = @GroupID
END;