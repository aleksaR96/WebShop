CREATE PROC SelectPropertyValue
@ID int
AS
BEGIN
	SELECT *
	FROM PropertyValues
	WHERE ID = @ID
END;