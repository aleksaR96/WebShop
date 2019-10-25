CREATE PROC SelectPropertyGroupsByCategoryID
@CategoryID int
AS
BEGIN
	SELECT *
	FROM PropertyGroups
	WHERE CategoryID = @CategoryID
END;