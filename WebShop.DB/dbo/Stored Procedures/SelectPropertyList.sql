CREATE PROC SelectPropertyList
@ID int
AS
BEGIN
	SELECT *
	FROM PropertyList
	WHERE ID = @ID
END;